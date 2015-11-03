namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Enumerations;

    public class Notification
    {
        public Notification()
        {
            this.Status = NotificationStatus.NotSeen;
        }

        [Key]
        public virtual int Id { get; set; }

        [Required]
        public virtual string CreatorId { get; set; }

        public virtual User Creator { get; set; }

        [Required]
        public virtual string RecipientId { get; set; }

        public virtual User Recipient { get; set; }

        [Required]
        public virtual string Content { get; set; }

        [Required]
        public virtual DateTime Date { get; set; }

        [Required]
        public NotificationType Type { get; set; }

        public NotificationStatus Status { get; set; }
    }
}