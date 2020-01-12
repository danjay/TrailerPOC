using NServiceBus;
using NServiceBus.Logging;
using System;

namespace Domain
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.Title = "Trailers.Domain";
            LogManager.Use<DefaultFactory>().Level(LogLevel.Info);
            var endpointConfiguration = new EndpointConfiguration("Trailers.Domain");
            endpointConfiguration.UsePersistence<LearningPersistence>();
            endpointConfiguration.UseTransport<LearningTransport>();

            var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);

            Console.WriteLine("Press enter to send a message");
            Console.WriteLine("Press any key to exit");

            #region ClientLoop

            while (true)
            {
                var key = Console.ReadKey();
                Console.WriteLine();

                if (key.Key != ConsoleKey.Enter)
                {
                    break;
                }
                
            }

            #endregion
        }
    }
}
