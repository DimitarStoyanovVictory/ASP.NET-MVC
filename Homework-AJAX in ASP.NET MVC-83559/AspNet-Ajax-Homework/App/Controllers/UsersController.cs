namespace App.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Models;

    public class UsersController : Controller
    {
        public JsonResult Check(string username)
        {
            var context = new ApplicationDbContext();
            var result = context.Users.Where(u => u.UserName.Equals(username)).FirstOrDefault();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}