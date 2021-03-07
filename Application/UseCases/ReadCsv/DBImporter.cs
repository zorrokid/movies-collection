using System.Collections.Generic;

namespace Application.UseCases.ReadCsv
{
    public interface IDBBImporter
    {
        void import(IEnumerable<CsvRow> csvRows);
    }

    public class DirectorImporter : IDBBImporter
    {
        public void import(IEnumerable<CsvRow> csvRows)
        {
            throw new System.NotImplementedException();
        }
    }
}