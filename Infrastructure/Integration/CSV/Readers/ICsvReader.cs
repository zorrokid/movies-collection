using System.Collections.Generic;

namespace Infrastructure.Integration.CSV.Readers
{
    public interface ICsvReader<TRowModel>
    {
         IEnumerable<TRowModel> ReadCsv(string filePath, string delimiter = ",");
    }
}