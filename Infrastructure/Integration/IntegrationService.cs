using Application.Interfaces;
using Infrastructure.Integration.CSV.Readers;

namespace Infrastructure.Integration
{
    public class IntegrationService : IIntegration
    {
        private readonly ICsvReader reader;

        public IntegrationService(ICsvReader reader)
        {
            this.reader = reader;
        }
        
        public void ImportPublicationItems(string resourcePath)
        {
            throw new System.NotImplementedException();
        }

        public void ImportPublications(string resourcePath)
        {
            reader.ReadCsv(resourcePath);
        }
    }
}