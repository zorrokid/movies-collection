namespace Domain.Entities
{
    public class Person : BaseEntity
    {
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
    }
}