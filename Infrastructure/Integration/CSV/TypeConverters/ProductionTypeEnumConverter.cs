using System;
using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Domain.Enumerations;
using Infrastructure.Integration.CSV.Exceptions;

namespace Infrastructure.Integration.CSV.TypeConverters
{
    public class ProductionTypeEnumConverter : DefaultTypeConverter
    {
        private static Dictionary<String, ProductionTypeEnum> EnumStringMap = new Dictionary<String, ProductionTypeEnum>
        {
            { "movie", ProductionTypeEnum.Movie },
            { "documentary", ProductionTypeEnum.Document },
            { "tv Serie", ProductionTypeEnum.TvSerie },
            { "music", ProductionTypeEnum.Music }
        };

        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text)) return ProductionTypeEnum.Undefined;
            
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