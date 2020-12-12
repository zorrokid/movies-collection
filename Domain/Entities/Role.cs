namespace Domain.Entities
{
    public class Role
    {
        public int Id { get; private set; }
        public string RoleName { get; private set; }

        public Role(int id, string roleName)
        {
            Id = id;
            RoleName = roleName;
        }
    }
}