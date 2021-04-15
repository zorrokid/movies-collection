namespace Application.Interfaces
{
    public interface IIntegration
    {
         void ImportPublications(string resourcePath);
         void ImportPublicationItemss(string resourcePath);
    }
}