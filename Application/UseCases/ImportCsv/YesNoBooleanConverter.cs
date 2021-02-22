using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Application.UseCases.ImportCsv
{
    public class YesNoBooleanConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            string txtToBool = text.Trim().ToLower();
            if (txtToBool != "yes" && txtToBool != "no") throw new CvsImportException("Values 'yes' or 'no' accepted for type conversion to boolean.");
            return txtToBool == "yes";
        }

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            return ((bool) value) == true ? "yes" : "no";
        }
    }
}