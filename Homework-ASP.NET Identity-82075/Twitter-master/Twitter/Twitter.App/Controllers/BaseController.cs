namespace Twitter.App.Controllers
{
    using System.Web.Mvc;
    using Twitter.Data.UnitOfWork;

    public class BaseController : Controller
    {
        private ITwittertData data;

        public BaseController(ITwittertData data)
        {
            this.data = data;
        }

        protected ITwittertData Data
        {
            get
            {
                return this.data;
            } 
            
        }
    }
}