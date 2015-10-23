namespace Twitter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tweet
    {
        private ICollection<User> favoritedUsers;
        private ICollection<User> retweeters;
        private ICollection<Reply> replies; 

        public Tweet()
        {
            this.favoritedUsers = new HashSet<User>();
            this.retweeters = new HashSet<User>();
            this.replies = new HashSet<Reply>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        [DefaultValue(false)]
        public bool IsReported{ get; set; }

        public virtual ICollection<User> FavoritedUsers
        {
            get { return this.favoritedUsers; }
            set { this.favoritedUsers = value; }
        }

        public virtual ICollection<User> Retweeters
        {
            get { return this.retweeters; }
            set { this.retweeters = value; }
        }

        public virtual ICollection<Reply> Replies
        {
            get { return this.replies; }
            set { this.replies = value; }
        }
    }
}
