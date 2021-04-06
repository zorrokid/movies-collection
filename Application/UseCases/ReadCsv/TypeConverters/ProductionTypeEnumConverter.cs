using System;
using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Domain.Enumerations;

namespace Application.UseCases.ReadCsv.TypeConverters
{
    public class ProductionTypeEnumConverter : DefaultTypeConverter
    {
        private static Dictionary<String, ProductionTypeEnum> EnumStringMap = new Dictionary<String, ProductionTypeEnum>
        {
            { "Movie", ProductionTypeEnum.Movie },
            { "Documentary", ProductionTypeEnum.Document },
            { "TV Serie", ProductionTypeEnum.TvSerie },
            { "Music", ProductionTypeEnum.Music }
        };

        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            string enumKey = text.Trim().ToLower();
            ProductionTypeEnum productionType;
            try
            {
                productionType = EnumStringMap[enumKey];
            }
            catch(Exception e)
            {
                throw new CsvImportException($"Failed converting production type string {text} to enumeration.", e);
            }
            return productionType;
        }

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            throw new NotImplementedException();
        }
    }
}