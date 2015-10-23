namespace Twitter.Models
{
    using System;

    public class Reply
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DateSent { get; set; }

        public string SenderId { get; set; }

        public virtual User Sender{ get; set; }

        public int TweetId { get; set; }

        public virtual Tweet Tweet{ get; set; }
    }
}
