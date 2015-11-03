namespace Twitter.App.Controllers
{
    using Data.UnitOfWork;
    using System.Web.Mvc;
    using Hubs;
    using Microsoft.AspNet.SignalR;

    public class NotificationsController : BaseController
    {
        public NotificationsController(ITwitterData data)
            : base(data)
        {
        }

        public ActionResult SendNotification(string type, string notification)
        {
            var notificationHub = GlobalHost.ConnectionManager.GetHubContext<TwitterHub>();
            notificationHub.Clients.All.SendNotification(type, notification);
            return this.Content("Notification sent.<br />");
        }
    }
}