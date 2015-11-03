namespace Tiwtter.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Twitter.Models;
    using Twitter.Models.Enumerations;
    using Twitter.Web.Controllers;
    using Twitter.Web.Models.ViewModels.Tweet;

    public class TweetController : BaseController
    {
        [Authorize]
        [HttpGet]
        public ActionResult Retweet(int id)
        {
            var tweet = this.Data.Tweets.Find(id);

            if (tweet == null)
            {
                throw new NotImplementedException("Tweet does not exists");
            }

            var user = this.Data.Users.Find(this.User.Identity.GetUserId());

            if (user.Tweets.Any(t => t.ReplyToId == tweet.Id))
            {
                throw new Exception("You cannot retweet again");
            }

            var viewModel = new RetweetViewModel
            {
                TweetContent = tweet.Content,
                UserPicture = tweet.User.ProfileImageBase64,
                Username = tweet.User.UserName,
                TweetId = tweet.Id
            };

            return PartialView("_ReTweetPartial", viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Favourite(int id)
        {
            var tweet = this.Data.Tweets.Find(id);

            if (tweet == null)
            {
                throw new NotImplementedException("Tweet does not exists");
            }

            var user = this.Data.Users.Find(this.User.Identity.GetUserId());

            if (user.FavouritedTweets.Any(t => t == tweet))
            {
                user.FavouritedTweets.Remove(tweet);
            }
            else
            {
                user.FavouritedTweets.Add(tweet);
                tweet.User.Notifications.Add(new Notification()
                {
                    Content = "favourite",
                    RecipientId = tweet.UserId,
                    Date = DateTime.Now,
                    CreatorId = user.Id,
                    Type = NotificationType.FavouriteTweet,
                });

                //TwitterHub hub = new TwitterHub();

                //hub.NotificationInform(new List<string>() { tweet.User.UserName });
            }

            this.Data.SaveChanges();

            return null;
        }
    }
}