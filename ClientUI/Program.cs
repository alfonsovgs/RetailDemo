using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Threading.Tasks;

namespace ClientUI
{
    class Program
    {
        private static ILog log = LogManager.GetLogger<Program>();
        
        static async Task Main(string[] args)
        {
            Console.Title = "ClientUI";
            
            var endpointConfiguration = new EndpointConfiguration("ClientUI");
            var trasnport = endpointConfiguration.UseTransport<LearningTransport>();

            var endpointInstance = await Endpoint.Start(endpointConfiguration);

            await RunLoop(endpointInstance);

            await endpointInstance.Stop();
        }

        static async Task RunLoop(IEndpointInstance endpointInstance)
        {
            while (true)
            {
                log.Info("Press 'P' to place an order, or 'Q' to quit.");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.P:
                        var command = new PlaceOrder
                        {
                            OrderId = Guid.NewGuid().ToString()
                        };

                        log.Info($"Sending PlaceOrder command, OrderId = {command.OrderId}");
                        await endpointInstance.SendLocal(command)
                            .ConfigureAwait(false);
                        break;

                    case ConsoleKey.Q:
                        return;

                    default:
                        log.Info("Unknown input. Please try again.");
                        break;
                }
            }
        }
    }
}
