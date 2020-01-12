using Messages.Commands;
using Messages.Events;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RegisterTrailerCommandHandler : IHandleMessages<RegisterTrailersCommand>
    {
        public Task Handle(RegisterTrailersCommand command, IMessageHandlerContext context)
        {
            Console.WriteLine($"Received register trailers command {command.ToString()}");
            var keeper = new KeeperAggregate(command.KeeperId);
            var trailers = new List<Guid>();

            foreach (var trailer in command.Trailers)
            {
                trailers.Add(keeper.RegisterTrailer(trailer.Vin, trailer.Manufacturer, trailer.Weight));
            }
            
            keeper.Save();

            var trailersRegistered = new TrailersRegistered
            {
                KeeperId = keeper.KeeperId,
                Trailers = trailers
            };

            Console.WriteLine($"Publishing TrailersRegistered, KeeperId = {keeper.KeeperId}");

            return context.Publish(trailersRegistered);
        }
    }
}
