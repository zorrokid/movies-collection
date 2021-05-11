using System.Collections.Generic;
using Infrastructure.Integration.CSV.Models;

namespace Infrastructure.Integration.CSV.Readers
{
    public interface ICsvReader
    {
         void ReadCsv(string filePath);
    }
}