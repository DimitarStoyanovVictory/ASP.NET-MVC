namespace Twitter.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data;

    public class UserController : BaseController
    {
        public UserController(ITwitterData twitterData)
            : base(twitterData)
        {
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        public ActionResult GetAllUsers()
        {
            var users = TwitterData.TwitterData.Users.ToList();

            return View();
        }


        public ActionResult DeleteUser()
        {
            return View();
        }

        public ActionResult UpdateUser()
        {
            return View();
        }
    }
}