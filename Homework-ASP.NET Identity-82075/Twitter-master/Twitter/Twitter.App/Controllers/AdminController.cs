namespace Twitter.App.Controllers
{
    using System.Web.Mvc;
    using Twitter.Models;

    using Twitter.Data.UnitOfWork;

    public class AdminController : BaseController
    {
        public AdminController(ITwittertData data) : base(data)
        {
        }

        public AdminController() : this(new TwitterData())
        {
        }

        public ActionResult Home(User user)
        {
            return View(user);
        }
    }
}