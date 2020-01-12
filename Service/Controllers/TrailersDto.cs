using System;
using System.Collections.Generic;

namespace Service.Controllers
{
    public class TrailersDto
    {
        public TrailersDto()
        {
            Trailers = new List<TrailerDto>();
            Payment = new PaymentDto();
        }

        public Guid KeeperId { get; set; }
        public PaymentDto Payment { get; set; }
        public IEnumerable<TrailerDto> Trailers { get; set; }

        public class TrailerDto
        {
            public string Vin { get; set; }
            public string Manufacturer { get; set; }
            public int Weight { get; set; }
        }

        public class PaymentDto
        {
            public int Id { get; set; }
            public decimal Amount { get; set; }
        }
    }
}