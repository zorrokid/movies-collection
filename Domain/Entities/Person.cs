namespace Domain.Entities
{
    public class Person : NameEntity
    {
        public string GivenName { get; set; }
        public string Surname { get; set; }
    }
}