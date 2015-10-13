namespace MyTwitter.Web.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;

    using MyTwitter.Models;

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}