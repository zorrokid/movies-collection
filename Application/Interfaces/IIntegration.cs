namespace Application.Interfaces
{
    public interface IIntegration
    {
         void ImportPublications(string resourcePath);
         void ImportPublicationItems(string resourcePath);
    }
}