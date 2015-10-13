namespace MyTwitter.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    public class TestController : BaseController
    {
        public ActionResult Move()
        {
            return this.View();
        }

        [System.Web.Http.Route("/test/all")]
        public ActionResult GetAllTwittsByUser()
        {
            var userId = this.User.Identity.GetUserId();

            var twitts = this.Data.Twitts.All().Where(t => t.AuthorId == userId);
            foreach (var twitt in twitts)
            {
                
            }
            return this.View(twitts);
        }
    }
}