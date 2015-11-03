namespace Tiwtter.Web.Controllers
{
    using System.Web.Mvc;

    public class UserController : Controller
    {
        public ActionResult Profile()
        {
            return View();
        }
    }
}