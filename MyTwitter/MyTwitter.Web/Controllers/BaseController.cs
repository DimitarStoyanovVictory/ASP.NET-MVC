namespace MyTwitter.Web.Controllers
{
    using System.Web.Mvc;
    using Data;
    using Data.UnitOfWorks;

    public class BaseController : Controller
    {
        private readonly IData data;

        public BaseController()
            : this(new TwitterData(new MyTwitterContext()))
        {
        }

        public BaseController(IData data)
        {
            this.data = data;
        }

        protected IData Data
        {
            get
            {
                return this.data;
            }
        }
    }
}