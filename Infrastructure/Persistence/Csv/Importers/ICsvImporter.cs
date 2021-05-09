using Infrastructure.Persistence.Csv.Models;

namespace Infrastructure.Persistence.Csv.Importers
{
    public interface ICsvImporter
    {
         void Import(CsvRow csvRow);
    }
}