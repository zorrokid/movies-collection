using Application.Interfaces;
using Infrastructure.Persistance.Csv.Readers;

namespace Infrastructure.Integration
{
    public class Integration : IIntegration
    {
        private readonly ICsvReader reader;

        public Integration(ICsvReader reader)
        {
            this.reader = reader;
        }
        
        public void ImportPublicationItemss(string resourcePath)
        {
            throw new System.NotImplementedException();
        }

        public void ImportPublications(string resourcePath)
        {
            reader.ReadCsv(resourcePath);
        }
    }
}