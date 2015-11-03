namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Message
    {
        public Message()
        {
            this.Seen = false;
            this.Deleted = false;
        }

        [Key]
        public virtual int Id { get; set; }

        [Required]
        public virtual string SenderId { get; set; }

        public virtual User Sender { get; set; }

        [Required]
        public virtual string ReceiverId { get; set; }

        public virtual User Receiver { get; set; }

        [Required]
        public virtual string Content { get; set; }

        public virtual bool Deleted { get; set; }

        public virtual bool Seen { get; set; }

        [Required]
        public virtual DateTime SentDateTime { get; set; }
    }
}