using System;
using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Domain.Enumerations;

namespace Infrastructure.Integration.CSV.TypeConverters
{
    public class CaseTypeEnumConverter : DefaultTypeConverter
    {
        private static Dictionary<String, CaseTypeEnum> EnumStringMap = new Dictionary<String, CaseTypeEnum>
        {
            { "keepcase",  CaseTypeEnum.KeepCase },
            { "snapcase", CaseTypeEnum.SnapperCase },
            { "mediabook", CaseTypeEnum.MediaBook },
            { "steelbook", CaseTypeEnum.SteelBook },
            { "slimcase", CaseTypeEnum.SlimCase },
            { "wood box", CaseTypeEnum.SpecialBox },
            { "deluxe box", CaseTypeEnum.SpecialBox },
            { "digipack", CaseTypeEnum.Digipack }  
        };

        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            string enumKey = text.Trim().ToLower();
            
            CaseTypeEnum caseType = CaseTypeEnum.Undefined;
            
            if (EnumStringMap.ContainsKey(enumKey))
            {
                caseType = EnumStringMap[enumKey];
            }
            return caseType;
        }

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            throw new NotImplementedException();
        }
    }
}