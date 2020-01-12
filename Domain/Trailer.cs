using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Trailer : IEntity
    {
        public Trailer(string vin, string manufacturer, int weight)
        {
            TrailerId = Guid.NewGuid();
            Vin = vin;
            Manufacturer = manufacturer;
            Weight = weight;
        }

        public Guid TrailerId { get; private set; }
        public string Vin { get; private set; }
        public string Manufacturer { get; private set; }
        public int Weight { get; private set; }
    }
}
