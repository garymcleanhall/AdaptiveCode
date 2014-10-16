using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:7617/api/values";

            MakeGetRequest(uri);
            MakePostRequest(uri);

            Console.ReadKey();
        }

        private static async void MakeGetRequest(string uri)
        {
            var restClient = new HttpClient();
            var getRequest = await restClient.GetStringAsync(uri);

            Console.WriteLine(getRequest);
        }

        private static async void MakePostRequest(string uri)
        {
            var restClient = new HttpClient();
            var postRequest = await restClient.PostAsync(uri, 
                new StringContent("Data to send to the server"));

            var responseContent = await postRequest.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);
        }
    }
}
