using System;
using System.Linq;
using System.Web.Mvc;

namespace ASP_NET_MVC_Caching_Homework.Controllers
{
    using System.Web.Caching;
    using Models;

    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            var db = new ApplicationDbContext();

            IQueryable<ApplicationUser> users;
            if (this.HttpContext.Cache["Users"] == null)
            {
                users = db.Users
                    .OrderBy(u => u.UserName);

                this.HttpContext.Cache.Add("Users", users, null, DateTime.Now.AddMinutes(10), TimeSpan.Zero,
                                                                                        CacheItemPriority.Default, null);
            }
            users = this.HttpContext.Cache["Users"] as IQueryable<ApplicationUser>;
            
            return View(users);
        }
    }
}