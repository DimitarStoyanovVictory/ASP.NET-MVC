using System.Web.Mvc;

namespace ASP.NET_01.Overview.Controllers
{
    using Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Vlado()
        {
            var obj = new LoginViewModel { Email = "vlado@softuni.bg", Password = "mn0g0slovjaaparola", RememberMe = true };
            return this.View("Vlado", obj);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}