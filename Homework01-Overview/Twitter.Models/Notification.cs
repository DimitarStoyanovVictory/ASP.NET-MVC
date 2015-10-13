namespace Twitter.Models
{
    using System;

    public class Notification
    {
        public virtual int Id { get; set; }

        public virtual string Content { get; set; }

        public virtual DateTime HappendAt { get; set; }

        public virtual int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
