using System;
using Microsoft.AspNet.Identity;
using Twitter.App.Models;
using Twitter.Models;

namespace Twitter.App.Controllers
{
    using System.Web.Mvc;
    using Twitter.Data.UnitOfWork;

    [Authorize]
    public class TweetsController : BaseController
    {
        public TweetsController(ITwittertData data) : base(data)
        {
        }

        public TweetsController() : this(new TwitterData())
        {
        }

        public ActionResult Tweet()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Tweet(TweetBindingModel model)
        {
            var loggedUser = this.Data.Users.Find(this.User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                var tweet = new Tweet
                {
                    Content = model.Content,
                    PublishDate = DateTime.Now,
                    OwnerId = loggedUser.Id
                };
                this.Data.Tweets.Add(tweet);
                this.Data.SaveChanges();
                return RedirectToAction("UserHome", "Home");
            }
            ModelState.AddModelError("contentError", "Message");
            return RedirectToAction("Tweet", "Tweets", model) ;
        }
    }
}