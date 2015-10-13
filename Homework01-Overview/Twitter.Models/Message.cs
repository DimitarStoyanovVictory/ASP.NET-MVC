namespace Twitter.Models
{
    using System;

    public class Message
    {
        public virtual int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public virtual DateTime? SentDate { get; set; }

        public virtual int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
