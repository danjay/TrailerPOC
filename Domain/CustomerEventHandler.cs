using Messages.Commands;
using Messages.Events;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CustomerEventHandler : IHandleMessages<ICustomerEvent>
    {
        public Task Handle(ICustomerEvent command, IMessageHandlerContext context)
        {
            Console.WriteLine($"Received register trailers command {command.ToString()}");

            //send event to mibi

            return Task.CompletedTask;
        }
    }
}
