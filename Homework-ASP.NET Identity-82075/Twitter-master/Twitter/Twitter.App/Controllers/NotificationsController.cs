namespace Twitter.App.Controllers
{
    using Twitter.Data.UnitOfWork;

    public class NotificationsController : BaseController
    {
        public NotificationsController(ITwittertData data) : base(data)
        {
        }

        public NotificationsController() : this(new TwitterData())
        {
        }
    }
}