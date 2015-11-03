namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Report
    {
        [Key]
        public virtual int Id { get; set; }

        [Required]
        public virtual int UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public virtual int TweetId { get; set; }

        public virtual Tweet Tweet { get; set; }

        [Required]
        public virtual DateTime Date { get; set; }

        [Required]
        public virtual string Description { get; set; }
    }
}