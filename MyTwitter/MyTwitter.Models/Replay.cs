namespace MyTwitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Replay
    {
        public Replay()
        {
            this.PublishedOn = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime PublishedOn { get; set; }

        [Required]
        public int TwittId { get; set; }

        [ForeignKey("TwittId")]
        public virtual Twitt Twitt { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }
    }
}