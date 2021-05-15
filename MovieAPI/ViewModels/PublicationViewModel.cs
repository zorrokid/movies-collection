
namespace movieAPI.ViewModels
{
    public class PublicationViewModel
    {
        public int Id { get; private set; }

        public PublicationViewModel(int id)
        {
            Id = id;
        }
    }
}
