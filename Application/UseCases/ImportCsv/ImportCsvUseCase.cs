using System.Collections.Generic;
using Application.Models;

namespace Application.UseCases.ImportCsv
{
    public interface IImportCsvUseCase
    {
        void Import(IEnumerable<CsvRow> rows);
    }

    public class ImportCsvUseCase : IImportCsvUseCase
    {
        private readonly List<IDBImporter> importers;

        public ImportCsvUseCase(List<IDBImporter> importers)
        {
            this.importers = importers;
        }

        public void Import(IEnumerable<CsvRow> rows)
        {

        }
    }
}