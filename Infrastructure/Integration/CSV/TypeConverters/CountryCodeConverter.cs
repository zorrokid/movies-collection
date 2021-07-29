using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Infrastructure.Integration.CSV.TypeConverters
{
    public class CountryCodeConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            switch(text.Trim().ToLower())
            {
                case "nordic": return new string[]{"fi", "se", "no", "dk"};
                case "finland": return new string []{"fi"};
                case "sweden": return new string []{"se"};
                case "denmark": return new string []{"dk"};
                case "norway": return new string []{"no"};
                case "germany": return new string []{"de"};
                case "canada": return new string []{"ca"};
                case "netherlands": return new string []{"nl"};
                case "portugal": return new string []{"pt"};
                case "south africa": return new string []{"za"};
                case "spain": return new string []{"es"};
                case "united states": return new string []{"us"};
                case "united kingdom": return new string []{"gb"};
                default: return new string[]{};
            }
        }
    }
}