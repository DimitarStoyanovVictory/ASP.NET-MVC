namespace App.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Search(string cityName)
        {
            var context = new ApplicationDbContext();
            var data = context.Cities
                .Where(c => c.Name.StartsWith(cityName))
                .OrderBy(c => c.Name)
                .Select(c => c.Name);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult List()
        {
            var context = new ApplicationDbContext();
            var people = context.People;
            return View(people);
        }

        public JsonResult Person(int id)
        {
            var context = new ApplicationDbContext();
            var person = context.People.FirstOrDefault(p => p.Id == id);


            return Json(person, JsonRequestBehavior.AllowGet);
        }
    }
}