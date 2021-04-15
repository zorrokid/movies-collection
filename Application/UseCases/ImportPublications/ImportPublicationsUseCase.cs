using Application.Interfaces;

namespace Application.UseCases.ImportCsv
{
    public interface IImportPublicationsUseCase
    {
        void Import(string publicationsResourcePath);
    }

    public class ImportPublicationsUseCase : IImportPublicationsUseCase
    {
        private readonly IIntegration integrarion;

        public ImportPublicationsUseCase(IIntegration integrarion)
        {
            this.integrarion = integrarion;
        }

        public void Import(string publicationsResourcePath)
        {

            integrarion.ImportPublications(publicationsResourcePath);
        }
    }
}