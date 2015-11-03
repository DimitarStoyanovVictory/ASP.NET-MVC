namespace Tiwtter.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity;
    using Twitter.App.Constants;
    using Twitter.Web.Controllers;
    using Twitter.Web.Models.ViewModels.Tweet;

    public class HomeController : BaseController
    {
        public ActionResult Index(int page = AppConstants.DefaultPageIndex)
        {
            List<TweetViewModel> tweets = new List<TweetViewModel>();

            if (User.Identity.IsAuthenticated)
            {
                var user = this.Data.Users.Find(this.User.Identity.GetUserId());

                var followersIds = user.FollowedUsers.Select(u => u.Id).ToList();

                tweets = this.Data.Tweets.All()
                   .Where(t => t.UserId == user.Id || followersIds.Contains(t.UserId))
                   .OrderByDescending(t => t.TweetDate)
                   .Skip((page - 1) * AppConstants.DefaultPageSize)
                   .Take(AppConstants.DefaultPageSize)
                   .ProjectTo<TweetViewModel>()
                   .ToList();

                return View("~/Views/Users/Index.cshtml", tweets);
            }

            tweets = this.Data.Tweets.All()
                    .OrderByDescending(t => t.TweetDate)
                    .Skip((page - 1) * AppConstants.DefaultPageSize)
                    .Take(AppConstants.DefaultPageSize)
                    .ProjectTo<TweetViewModel>()
                    .ToList();

            return View(tweets);
        }
    }
}