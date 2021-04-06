using System.Collections.Generic;
using Application.Models;

namespace Application.UseCases.ImportCsv
{
    public interface IImportCollectionsUseCase
    {
        void Import(IEnumerable<CsvRow> rows, List<ImportTypeEnum> importers);
    }

    public class ImportCollectionsUseCase : IImportCsvUseCase
    {
        private readonly DBImporterFactory factory;

        public ImportCollectionsUseCase(DBImporterFactory factory)
        {
            this.factory = factory;
        }

        public void Import(IEnumerable<CsvRow> rows, List<ImportTypeEnum> importers)
        {
            foreach(var importType in importers)
            {
                var importer = factory.GetImporter(importType);
                // importer.Import(rows);
            }
        }
    }
}