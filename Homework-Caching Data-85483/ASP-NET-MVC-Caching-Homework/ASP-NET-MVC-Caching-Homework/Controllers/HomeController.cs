using System.Web.Mvc;

namespace ASP_NET_MVC_Caching_Homework.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(CacheProfile = "Profile15Sec")]
        public ActionResult Index()
        {
            return View();
        }


        [OutputCache(Duration = 300, VaryByParam = "none")]
        public ActionResult RssFeed()
        {
            ViewBag.Feed = RssReader.GetFeed();
            return PartialView("_RssFeed");
        }

        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}