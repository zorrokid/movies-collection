

using System;

namespace Application.UseCases.ImportCsv
{
    public enum ImportTypeEnum
    {
        Director,
    }

    public class DBImporterFactory
    {
        private readonly IServiceProvider serviceProvider;

        public DBImporterFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IDBImporter GetImporter(ImportTypeEnum importType)
        {
            switch(importType)
            {
                case ImportTypeEnum.Director:
                    return (IDBImporter)serviceProvider.GetService(typeof(DirectorImporter));
            }
            throw new Exception($"No IDBImporter implementation for import type {importType}");
        }
   
    }
}