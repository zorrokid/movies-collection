
using System.Collections.Generic;

namespace MovieAPI.ViewModels
{
    public class PublicationViewModel
    {
        public int Id { get; set; }
        public string OriginalTitle { get; set; }
        public string LocalTitle { get; set; }
        public bool IsVerified { get; set; }
        public string[] CountryCodes { get; set; }
        public string Barcode { get; set; }
        public int CaseTypeId { get; set; }
        public string CaseTypeName { get; set; }
        public int ConditionClassId { get; set; }
        public string ConditionClassName { get; set; }
        public bool HasSlipCover { get; set; }
        public bool HasHologram { get; set; }
        public bool IsRental { get; set; }
        public string Notes { get; set; }
        public bool HasTwoSidedCover { get; set; }
        public bool HasBooklet { get; set; }
        public List<PublicationItemViewModel> PublicationItems { get; set; }
    }
}
