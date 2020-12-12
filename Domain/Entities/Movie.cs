using System.Collections.Generic;

namespace Domain.Entities
{
    public class Movie
    {
        public int Id { get; private set; }
        public string OriginalTitle { get; private set; }
        public string LocalTitle { get; private set; }

        public List<PersonRole> Directors { get; } = new List<PersonRole>();
    }
}