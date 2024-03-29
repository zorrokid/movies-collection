using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Production is something that represents of type ProductionType (e.g. movie, tv-series, documentary). 
    /// </summary>
    public class Production : BaseEntity
    {
        public int ProductionTypeId { get; set; }
        public ProductionType ProductionType { get; set; }
        public string OriginalTitle { get; set; }

        public string CountryCode { get; set; }
        public List<ProductionPersonRole> ProductionPersonRoles { get; } = new();
        public List<ProductionCompanyRole> ProductionCompanyRoles { get; } = new();
    
        public List<PublicationItem> PublicationItems { get; } = new();
    }
}