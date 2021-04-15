using System.Collections.Generic;
using Infrastructure.Persistance.Csv.Models;

namespace Infrastructure.Persistance.Csv.Readers
{
    public interface ICsvReader
    {
         IEnumerable<CsvRow> ReadCsv(string filePath);
    }
}