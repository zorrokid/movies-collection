using System.Collections.Generic;
using Domain.Enumerations;

namespace Infrastructure.Persistance.Csv.Models
{
    public class CsvRow
    {
        public bool IsChecked { get; set;}
        public string OriginalTitle { get; set;}
        public string LocalTitle { get; set;}
        public int? Year { get; set;}
        public ProductionTypeEnum ProductionType { get; set;}
        public MediaTypeEnum[] MediaType { get; set;}
        public string Edition { get; set; }
        public string Country { get; set; }
        public CaseTypeEnum CaseType { get; set; }
        public int? Discs { get; set; }
        public bool HasSubFi { get; set; }
        public bool HasSubEn { get; set; }
        public string AspectRatio { get; set; }
        public int? RunningTime { get; set; }
        public List<string> Directors { get; set; }
        public string Status { get; set; }
        public ConditionClassEnum Condition { get; set; }
        public string Notes { get; set; }
        public bool IsWatched { get; set; }
        public bool IsRental { get; set; }
        public bool HasSlipCover { get; set; }
        public bool HasTwoSidedCover { get; set; }
        public bool HasHologram { get; set; }
        public int? Id { get; set; }
        public string Barcode { get; set; }
        public string IMDBCode { get; set; }
        public int? CollectionId { get; set; }	
        public string Series { get; set; }
        public string Publisher { get; set; }	
        public string Studio { get; set; }	
        public bool HasLeaflet { get; set; }
        public bool HasSceneList { get; set; }
        public bool IsTwoSidedDisc { get; set; }
    }
}
