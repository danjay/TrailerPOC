using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messages.Events
{
    public class TrailersRegistered : IEvent, IMibiEvent
    {
        public Guid KeeperId { get; set; }
        public List<Guid> Trailers { get; set; }
    }
}
