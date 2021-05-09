using System.Collections.Generic;
using Infrastructure.Persistence.Csv.Models;

namespace Infrastructure.Persistence.Csv.Readers
{
    public interface ICsvReader
    {
         void ReadCsv(string filePath);
    }
}