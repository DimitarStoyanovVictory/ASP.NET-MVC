namespace CachingWebApi.Controllers
{
    using System.Web.Mvc;
    using Models;

    public class HomeController : BaseApiController
    {
        public HomeController(ApplicationDbContext context) : base(context)
        {
        }

        [OutputCache(CacheProfile = "ChagingHomePage")]
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 300)]
        public PartialViewResult RSSFeed()
        {
            return PartialView("_RSSFeed");
        }
    }
}