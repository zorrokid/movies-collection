using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Infrastructure.Persistence.Csv.Exceptions;

namespace Infrastructure.Persistence.Csv.TypeConverters
{
    public class YesNoBooleanConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            string txtToBool = text.Trim().ToLower();
            if (txtToBool != "yes" && txtToBool != "no" && !string.IsNullOrEmpty(txtToBool)) throw new CsvImportException("Values 'yes', 'no' or empty (interpreted as 'no') accepted for type conversion to boolean.");
            return txtToBool == "yes";
        }

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            return ((bool) value) == true ? "yes" : "no";
        }
    }
}