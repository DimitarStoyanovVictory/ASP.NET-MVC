namespace Twitter.App.Hubs
{
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;

    [HubName("notifications")]
    public class TwitterHub : Hub
    {
        public void SendNotification(string type, string notificiation)
        {
            Clients.Others.reciveNotification(type, notificiation);
        } 
    }
}