using System;
using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Domain.Enumerations;

namespace Infrastructure.Integration.CSV.TypeConverters
{
    public class ConditionClassEnumConverter : DefaultTypeConverter
    {
        private static Dictionary<String, ConditionClassEnum> EnumStringMap = new Dictionary<String, ConditionClassEnum>
        {
           { "still wrapped",ConditionClassEnum.New },
           { "poor - slightly damaged",ConditionClassEnum.Poor },
           { "bad - damaged",ConditionClassEnum.Bad },
           { "good",ConditionClassEnum.Good },
           { "fair",ConditionClassEnum.Fair },
           { "excellent",ConditionClassEnum.Excellent },
           
        };

        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            string enumKey = text.Trim().ToLower();
            
            ConditionClassEnum condition = ConditionClassEnum.Undefined;
            
            if (EnumStringMap.ContainsKey(enumKey))
            {
                condition = EnumStringMap[enumKey];
            }
            return condition;
        }

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            throw new NotImplementedException();
        }
    }
}

