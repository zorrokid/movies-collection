using System.Collections.Generic;

namespace Domain.Entities
{
    public class Production : BaseEntity
    {
        public ProductionType ProductionType { get; set; }
        public string OriginalTitle { get; set; }

        public string CountryCode { get; set; }
        public List<PersonRole> Persons { get; } = new List<PersonRole>();
        public List<CompanyRole> Companies { get; } = new List<CompanyRole>();
    }
}