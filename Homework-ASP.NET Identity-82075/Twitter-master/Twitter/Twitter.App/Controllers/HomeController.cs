using Microsoft.AspNet.Identity;
using Twitter.App.Models;

namespace Twitter.App.Controllers
{
    using System.Linq;
    using Twitter.App.Models.ViewModels;
    using System.Web.Mvc;
    using Twitter.Data.UnitOfWork;

    public class HomeController : BaseController
    {
        public HomeController(ITwittertData data) : base(data)
        {
        }

        public HomeController() : this(new TwitterData())
        {
        }

        public ActionResult Index(int? page)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("UserHome", "Home");
            }

            int pageNumber = page == null ? 1 : int.Parse(page.ToString());
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            int pageSize = 4;
            ViewBag.pageNumber = pageNumber;

            var tweets = this.Data.Tweets.All()
                .OrderByDescending(t => t.PublishDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList()
                .Select(t => new TweetViewModel(t));


            return View(tweets);
        }

        public ActionResult UserHome(int? page)
        {
            var loggedUser = this.Data.Users.Find(User.Identity.GetUserId());

            if (User.IsInRole("Administrator"))
            {
                return RedirectToAction("Home", "Admin", loggedUser);
            }

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            int pageNumber = page == null ? 1 : int.Parse(page.ToString());
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            int pageSize = 4;

            ViewBag.pageNumber = pageNumber;

            var followedUserIds = this.Data.Users.Find(loggedUser.Id)
                .FollowedUsers.Select(f => f.Id);

            var tweets = this.Data.Tweets.All()
                .Where(t => followedUserIds.Contains(t.Owner.Id) || loggedUser.Id == t.OwnerId)
                .OrderByDescending(t => t.PublishDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList()
                .Select(t => new TweetViewModel(t));

            return View(tweets);
        }
    }
}