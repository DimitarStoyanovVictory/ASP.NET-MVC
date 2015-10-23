namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime DateSent { get; set; }

        [Required]
        public string SenderId { get; set; }

        public virtual User Sender{ get; set; }

        [Required]
        public string RecieverId { get; set; }

        public virtual User Reciever { get; set; }
    }
}
