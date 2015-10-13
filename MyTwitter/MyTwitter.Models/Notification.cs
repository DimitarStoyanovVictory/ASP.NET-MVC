namespace MyTwitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Notification
    {
        public Notification()
        {
            this.PubishedOn = DateTime.Now;
            this.IsRead = false;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime PubishedOn { get; set; }

        public DateTime? ReadOn { get; set; }

        public bool IsRead { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}