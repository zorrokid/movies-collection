using Infrastructure.Integration.CSV.Models;

namespace Infrastructure.Integration.CSV.Importers
{
    public interface ICsvImporter<TRowModel>
    {
         void Import(TRowModel csvRow);
    }
}