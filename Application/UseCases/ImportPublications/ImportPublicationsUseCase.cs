using Application.Interfaces;

namespace Application.UseCases.ImportCsv
{
    public interface IImportPublicationsUseCase
    {
        void Import(string publicationsResourcePath);
    }

    public class ImportPublicationsUseCase : IImportPublicationsUseCase
    {
        private readonly IIntegration integration;

        public ImportPublicationsUseCase(IIntegration integration)
        {
            this.integration = integration;
        }

        public void Import(string publicationsResourcePath)
        {
            integration.ImportPublications(publicationsResourcePath);
        }
    }
}