using Infrastructure.Integration.CSV.Models;

namespace Infrastructure.Integration.CSV.Importers
{
    public interface ICsvImporter
    {
         void Import(CsvRow csvRow);
    }
}