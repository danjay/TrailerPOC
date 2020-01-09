using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class TrailerAggregate : IAggregate
    {
        public string FirstName { get; internal set; }

        public string LastName { get; internal set; }

        public TrailerAggregate(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public TrailerAggregate(Guid id)
        {

        }

        public void Save()
        {

        }
    }
}
