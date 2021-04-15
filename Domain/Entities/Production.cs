using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Production is something that represents of type ProductionType (e.g. movie, tv-series, documentary). 
    /// </summary>
    public class Production : BaseEntity
    {
        public ProductionType ProductionType { get; set; }
        public string OriginalTitle { get; set; }

        public string CountryCode { get; set; }
        public List<Person> Directors { get; } = new List<Person>();
        public List<Person> Producers { get; } = new List<Person>();
        public List<Person> Writers { get; } = new List<Person>();
        public Company Studio { get; set; }
    }
}