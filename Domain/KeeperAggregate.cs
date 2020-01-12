using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class KeeperAggregate : IAggregate
    {        
        public Guid KeeperId { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public List<Trailer> Trailers { get; private set; }

        public KeeperAggregate(string firstName, string lastName)
        {
            this.KeeperId = Guid.NewGuid();
            this.FirstName = firstName;
            this.LastName = lastName;
            Trailers = new List<Trailer>();
        }

        public KeeperAggregate(Guid id)
        {
            //load from db here
        }
        
        public Guid RegisterTrailer(string vin, string manufacturer, int weight)
        {
            var trailer = new Trailer(vin, manufacturer, weight);

            Trailers.Add(trailer);

            return trailer.TrailerId;
        }

        public void Save()
        {

        }
    }
}
