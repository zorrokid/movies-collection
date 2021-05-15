namespace Infrastructure.Integration.CSV.Readers
{
    public interface ICsvReader
    {
         void ReadCsv(string filePath, string delimiter = ",");
    }
}