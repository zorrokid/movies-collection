using System;
using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Domain.Enumerations;
using Infrastructure.Persistence.Csv.Exceptions;

namespace Infrastructure.Persistence.Csv.TypeConverters
{
    public class MediaTypeEnumConverter : DefaultTypeConverter
    {
        
        private static Dictionary<String, MediaTypeEnum[]> EnumStringMap = new Dictionary<String, MediaTypeEnum[]>
        {
            { "DVD", new MediaTypeEnum[] { MediaTypeEnum.DVD} },
            { "DVD+CD", new MediaTypeEnum[] { MediaTypeEnum.DVD, MediaTypeEnum.CD } },
            { "Blu-Ray", new MediaTypeEnum[] { MediaTypeEnum.BluRay } },
            { "Blu-Ray+DVD", new MediaTypeEnum[] { MediaTypeEnum.BluRay, MediaTypeEnum.DVD } },
            { "Blu-Ray 3D+Blu-Ray", new MediaTypeEnum[] { MediaTypeEnum.BluRay, MediaTypeEnum.BluRay3D } },
            { "Blu-Ray 3D+Blu-Ray+DVD", new MediaTypeEnum[] { MediaTypeEnum.BluRay, MediaTypeEnum.BluRay3D, MediaTypeEnum.DVD } },
            { "VHS", new MediaTypeEnum[] { MediaTypeEnum.VHS } }
        };

        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            string enumKey = text.Trim().ToLower();
            MediaTypeEnum[] caseType;
            try
            {
                caseType = EnumStringMap[enumKey];
            }
            catch(Exception e)
            {
                throw new CsvImportException($"Failed converting media type string {text} to list of enumerations.", e);
            }
            return caseType;
        }

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            throw new NotImplementedException();
        }
    }
}