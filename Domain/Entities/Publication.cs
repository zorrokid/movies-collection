
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Publication : BaseEntity
    {
        public string OriginalTitle { get; set; }
        public string LocalTitle { get; set; }
        public bool IsVerified { get; set; }
        public string CountryCode { get; set; }
        public string Barcode { get; set; }
        public CaseType CaseType { get; set; }
        public bool HasSlipCover { get; set; }
        public bool HasHologram { get; set; }
        public bool IsRental { get; set; }
        public string Notes { get; set; }
        public bool HasTwoSidedCover { get; set; }
        public bool HasBooklet { get; set; }
        public Company Publisher { get; set; }
        public int ImportOriginId { get; set; }
        public List<CoverLanguage> CoverLanguages { get; } = new List<CoverLanguage>();
    }
}