﻿namespace Twitter.App.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Models.ViewModels.Tweet;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;
    using Constants;
    using Data.UnitOfWork;
    using AutoMapper.QueryableExtensions;

    public class HomeController : BaseController
    {
        public HomeController(ITwitterData data) : base(data)
        {
        }

        public ActionResult Index(int page = AppConstants.DefaultPageIndex)
        {
            List<TweetViewModel> tweets = new List<TweetViewModel>();

            if (this.User.Identity.IsAuthenticated)
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