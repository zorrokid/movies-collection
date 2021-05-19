using System;
using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Domain.Enumerations;
using Infrastructure.Integration.CSV.Exceptions;

namespace Infrastructure.Integration.CSV.TypeConverters
{
    public class MediaTypeEnumConverter : DefaultTypeConverter
    {
        
        private static Dictionary<String, MediaTypeEnum[]> EnumStringMap = new Dictionary<String, MediaTypeEnum[]>
        {
            { "dvd", new MediaTypeEnum[] { MediaTypeEnum.DVD} },
            { "dvd+cd", new MediaTypeEnum[] { MediaTypeEnum.DVD, MediaTypeEnum.CD } },
            { "blu-ray", new MediaTypeEnum[] { MediaTypeEnum.BluRay } },
            { "blu-ray+dvd", new MediaTypeEnum[] { MediaTypeEnum.BluRay, MediaTypeEnum.DVD } },
            { "blu-ray 3d+blu-ray", new MediaTypeEnum[] { MediaTypeEnum.BluRay, MediaTypeEnum.BluRay3D } },
            { "blu-ray 3d+blu-ray+dvd", new MediaTypeEnum[] { MediaTypeEnum.BluRay, MediaTypeEnum.BluRay3D, MediaTypeEnum.DVD } },
            { "vhs", new MediaTypeEnum[] { MediaTypeEnum.VHS } }
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