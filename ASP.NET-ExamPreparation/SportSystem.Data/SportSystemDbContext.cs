namespace SportSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model;

    public class SportSystemDbContext : IdentityDbContext<User>
    {
        public SportSystemDbContext()
            : base("SportSystemDbContext", false)
        {
        }

        public static SportSystemDbContext Create()
        {
            return new SportSystemDbContext();
        }
    }
}