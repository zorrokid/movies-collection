namespace Domain.Entities
{
    public class Role : BaseEntity
    {
        public string RoleName { get; private set; }

        public Role(int id, string roleName)
        {
            Id = id;
            RoleName = roleName;
        }
    }
}