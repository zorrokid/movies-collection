
namespace movieAPI.ViewModels
{
    public class MovieVM
    {
        public int Id { get; private set; }
        public string OriginalTitle { get; private set; }
        public string LocalTitle { get; private set; }

        public MovieVM(int id, string originalTitle, string localTitle)
        {
            Id = id;
            OriginalTitle = originalTitle;
            LocalTitle = localTitle;
        }
    }
}
