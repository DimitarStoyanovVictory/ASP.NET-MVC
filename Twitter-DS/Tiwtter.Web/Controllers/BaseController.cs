namespace Twitter.Web.Controllers
{
    using System.Web.Mvc;
    using Data;
    using Data.UnitOfWork;

    public class BaseController : Controller
    {
        private ITwitterData data;

        public BaseController()
            : this(new TwitterData(new TwitterDbContext()))
        {
        }

        public BaseController(ITwitterData data)
        {
            this.data = data;
        }

        public ITwitterData Data
        {
            get { return this.data; }
        }
    }
}