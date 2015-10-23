namespace Twitter.App.Controllers
{
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Twitter.App.Models.ViewModels;

    using System.Web.Mvc;

    using Twitter.Data.UnitOfWork;

    public class UsersController : BaseController
    {
        public UsersController(ITwittertData data) : base(data)
        {
        }

        public UsersController() : this(new TwitterData())
        {
        }

        public ActionResult ViewProfile(string username)
        {
            var model = this.GetUserdata(username);
            if (model == null)
            {
                return RedirectToAction("UserHome", "Home");
            }
            return View(model);
        }

        private UserProfileViewModel GetUserdata(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                username = this.User.Identity.GetUserName();
            }

            var searchUser = this.Data.Users.All().FirstOrDefault(u => u.UserName == username);

            if (searchUser == null)
            {
                return null;
            }

            var model = new UserProfileViewModel(
                searchUser,
                searchUser.Tweets,
                searchUser.Followers,
                searchUser.FollowedUsers,
                searchUser.FavoriteTweets);

            return model;
            
        }
    }
}