using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messages.Events
{
    public class KeeperRegistered : IEvent, ICustomerEvent, IMibiEvent
    {
        public Guid KeeperId { get; set; }
    }
}
