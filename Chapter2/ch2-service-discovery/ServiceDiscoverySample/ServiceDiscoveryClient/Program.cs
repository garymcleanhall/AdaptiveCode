using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDiscoveryClient
{
    class Program
    {
        private const int a = 11894;
        private const int b = 27834;

        static void Main(string[] args)
        {
            var foundEndpoints = FindEndpointsByContract<ICalculator>();

            if (!foundEndpoints.Any())
            {
                Console.WriteLine("No endpoints were found.");
            }
            else
            {
                var binding = new BasicHttpBinding();
                var channelFactory = new ChannelFactory<ICalculator>(binding);
                foreach (var endpointAddress in foundEndpoints)
                {
                    var service = channelFactory.CreateChannel(endpointAddress);
                    var additionResult = service.Add(a, b);
                    Console.WriteLine("Service Found: {0}", endpointAddress.Uri);
                    Console.WriteLine("{0} + {1} = {2}", a, b, additionResult);
                }
            }

            Console.ReadKey();
        }

        private static IEnumerable<EndpointAddress> FindEndpointsByContract<TServiceContract>()
        {
            var discoveryClient = new DiscoveryClient(new UdpDiscoveryEndpoint());
            var findResponse = discoveryClient.Find(new FindCriteria(typeof(TServiceContract)));
            return findResponse.Endpoints.Select(metadata => metadata.Address);
        }
    }
}
