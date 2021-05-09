using System.Collections.Generic;

namespace Domain.Entities
{
    public class Person : NameEntity
    {
        public string GivenName { get; set; }
        public string Surname { get; set; }

        public List<Production> Productions { get; } = new List<Production>();
    }
}