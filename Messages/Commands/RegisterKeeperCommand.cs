using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messages.Commands
{
    public class RegisterKeeperCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
