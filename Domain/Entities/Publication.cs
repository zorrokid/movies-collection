
using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Publication is a container for publication items (movies, tv-serie seasons, documentaries etc).
    /// It has a case (usually) with barcode. Something that is sold in stores and contain some kind of media.
    /// </summary>
    public class Publication : BaseEntity
    {
        public string OriginalTitle { get; set; }
        public string LocalTitle { get; set; }
        public bool IsVerified { get; set; }
        public string CountryCode { get; set; }
        public string Barcode { get; set; }
        public CaseType CaseType { get; set; }
        public ConditionClass ConditionClass { get; set; }
        public bool HasSlipCover { get; set; }
        public bool HasHologram { get; set; }
        public bool IsRental { get; set; }
        public string Notes { get; set; }
        public bool HasTwoSidedCover { get; set; }
        public bool HasBooklet { get; set; }
        public Company Publisher { get; set; }
        public int ImportOriginId { get; set; }
        public List<PublicationItem> PublicationItems {get; } = new List<PublicationItem>();
        public List<CoverLanguage> CoverLanguages { get; } = new List<CoverLanguage>();
    }
}