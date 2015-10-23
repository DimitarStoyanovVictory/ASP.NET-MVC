namespace Twitter.App.Models.ViewModels
{
    using System;
    using Twitter.Models;

    public class RepliesViewModel
    {
        public RepliesViewModel(Reply reply)
        {
            this.Id = reply.Id;
            this.Content = reply.Content;
            this.DateSend = reply.DateSent;
            this.Sender = new UserViewModel(reply.Sender);
        }
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DateSend { get; set; }

        public UserViewModel Sender { get; set; }
    }
}