using CsvHelper.Configuration;
using Infrastructure.Persistance.Csv.Models;
using Infrastructure.Persistance.Csv.TypeConverters;

namespace Infrastructure.Persistance.Csv.RowMaps
{
    public class PublicationItemCsvRowMap : ClassMap<CsvRow>
    {
        public PublicationItemCsvRowMap()
        {
            Map(m => m.Id).Name("Id");
            Map(m => m.IsChecked).Name("Checked").TypeConverter<YesNoBooleanConverter>();
            Map(m => m.OriginalTitle).Name("Original title");
            Map(m => m.LocalTitle).Name("Local title");
            Map(m => m.Year).Name("Year");
            Map(m => m.ProductionType).Name("Media type").TypeConverter<ProductionTypeEnumConverter>();
            Map(m => m.MediaType).Name("Type").TypeConverter<MediaTypeEnumConverter>();
            Map(m => m.Edition).Name("Edition");
            Map(m => m.Country).Name("Country");
            Map(m => m.CaseType).Name("Case").TypeConverter<CaseTypeEnumConverter>();
            Map(m => m.Discs).Name("Discs");
            Map(m => m.HasSubFi).Name("Sub-fi").TypeConverter<YesNoBooleanConverter>();
            Map(m => m.HasSubEn).Name("Sub-en").TypeConverter<YesNoBooleanConverter>();
            Map(m => m.AspectRatio).Name("Aspect ratio");
            Map(m => m.RunningTime).Name("Running time");
            Map(m => m.Director).Name("Director");
            Map(m => m.Status).Name("Status");
            Map(m => m.Condition).Name("Condition");
            Map(m => m.Notes).Name("Notes");
            Map(m => m.IsWatched).Name("Watched").TypeConverter<YesNoBooleanConverter>();
            Map(m => m.IsRental).Name("Rental").TypeConverter<YesNoBooleanConverter>();
            Map(m => m.HasSlipCover).Name("Slip Cover").TypeConverter<YesNoBooleanConverter>();
            Map(m => m.HasHologram).Name("Hologram").TypeConverter<YesNoBooleanConverter>();
            Map(m => m.IsWatched).Name("Watched").TypeConverter<YesNoBooleanConverter>();
            Map(m => m.Barcode).Name("Barcode");
            Map(m => m.IMDBCode).Name("IMDB");
            Map(m => m.CollectionId).Name("Collection Id");
            Map(m => m.HasLeaflet).Name("Vihkonen").TypeConverter<YesNoBooleanConverter>();
            Map(m => m.HasSceneList).Name("Kohtausluettelo").TypeConverter<YesNoBooleanConverter>();
            Map(m => m.IsTwoSidedDisc).Name("2 Sided Disc").TypeConverter<YesNoBooleanConverter>();
            Map(m => m.HasTwoSidedCover).Name("2 Sided Cover").TypeConverter<YesNoBooleanConverter>();
            // 	Series	Publisher	Studio
        }
    }
}