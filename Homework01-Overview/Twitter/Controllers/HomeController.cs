using System.Web.Mvc;

namespace Twitter.Controllers
{
    using System.Linq;
    using Data;
    using WebGrease.Css.Extensions;

    public class HomeController : BaseController
    {
        public HomeController()
            : this(new TwitterDbContext())
        {
        }

        public HomeController(ITwitterData twitterData)
            : base(twitterData)
        {
        }

        public ActionResult Index()
        {
            var users = TwitterData.TwitterData.Users.ToList();
            var tweetsChronologicaly = TwitterData.TwitterData.Tweets.ToList();
            users.ForEach(u => u.Tweets.ForEach(t => tweetsChronologicaly.Add(t)));
            this.ViewBag.TweetsByChronology = tweetsChronologicaly;

            return View();
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