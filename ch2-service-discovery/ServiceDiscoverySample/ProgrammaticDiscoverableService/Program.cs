using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.Text;
using System.Threading.Tasks;

using ServiceContract;

namespace ProgrammaticDiscoverableService
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService)))
            {
                serviceHost.Description.Behaviors.Add(new ServiceDiscoveryBehavior());
                
                serviceHost.AddServiceEndpoint(new UdpDiscoveryEndpoint());
                serviceHost.AddServiceEndpoint(typeof(ICalculator), new BasicHttpBinding(), new Uri("http://localhost:8090/CalculatorService"));

                serviceHost.Open();

                Console.WriteLine("Discoverable Calculator Service is running...");
                Console.ReadKey();
            }
        }
    }
}
