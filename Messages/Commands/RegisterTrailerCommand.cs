using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messages.Commands
{
    public class RegisterTrailersCommand : ICommand
    {
        public RegisterTrailersCommand()
        {
            Trailers = new List<Trailer>();
            payment = new Payment();
        }

        public Guid KeeperId { get; set; }
        public IEnumerable<Trailer> Trailers { get; set; }
        public Payment payment { get; set; }
        
        public class Trailer
        {
            public string Vin { get; set; }
            public string Manufacturer { get; set; }
            public int Weight { get; set; }
        }

        public class Payment
        {
            public int Id { get; set; }
            public decimal Amount { get; set; }
        }
    }
}
