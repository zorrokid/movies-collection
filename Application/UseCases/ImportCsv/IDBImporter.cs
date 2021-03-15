using System.Collections.Generic;
using Application.Models;

namespace Application.UseCases.ImportCsv
{
    public interface IDBImporter
    {
        void Import(IEnumerable<CsvRow> csvRows);
    }
}