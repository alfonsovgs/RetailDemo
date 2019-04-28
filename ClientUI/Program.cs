using NServiceBus;
using System;
using System.Threading.Tasks;

namespace ClientUI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "ClientUI";
            
            var endpointConfiguration = new EndpointConfiguration("ClientUI");
            var trasnport = endpointConfiguration.UseTransport<LearningTransport>();

            var endpointInstance = await Endpoint.Start(endpointConfiguration);

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();

            await endpointInstance.Stop();
        }
    }
}
