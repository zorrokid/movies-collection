using Infrastructure.Persistance.Csv.Models;

namespace Infrastructure.Persistance.Csv.Importers
{
    public interface ICsvImporter
    {
         void Import(CsvRow csvRow);
    }
}