namespace Twitter.Controllers
{
    using ASP.NET_01.Overview.Controllers;
    using Data;

    public class BaseController : AccountController
    {
        public BaseController(ITwitterData twitterData)
        {
            TwitterData = twitterData;
        }

        protected ITwitterData TwitterData { get; set; }
    }
}