using Messages.Commands;
using Messages.Events;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RegisterKeeperCommandHandler : IHandleMessages<RegisterKeeperCommand>
    {
        public Task Handle(RegisterKeeperCommand command, IMessageHandlerContext context)
        {
            Console.WriteLine($"Received register keeper command {command.ToString()}");
            var keeper = new KeeperAggregate(command.FirstName, command.LastName);

            keeper.Save();

            var keeperRegistered = new KeeperRegistered
            {
                KeeperId = keeper.KeeperId
            };

            Console.WriteLine($"Publishing KeeperRegistered, KeeperId = {keeper.KeeperId}");

            return context.Publish(keeperRegistered);
        }
    }
}
