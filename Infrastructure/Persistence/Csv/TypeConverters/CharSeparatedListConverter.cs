using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Infrastructure.Persistence.Csv.TypeConverters
{
    public class CharSeparatedListConverter : DefaultTypeConverter
    {
        const char separatorChar = ';';
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            return text.Split(separatorChar, options: StringSplitOptions.TrimEntries);
        }
    }
}