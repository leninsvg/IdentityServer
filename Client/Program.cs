using IdentityModel.Client;
using System;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        private static async Task MainAsync()
        {
            // Discovery all the endpoints using metadata od identity server
            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");
            if(disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }
            // Configure acess client
            var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("ApiResource");

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }
            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("\n\n\n");
        }
    }
}
