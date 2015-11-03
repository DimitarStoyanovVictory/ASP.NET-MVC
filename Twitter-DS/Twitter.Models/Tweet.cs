namespace Twitter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tweet
    {
        private ICollection<User> favouritedBy;
        private ICollection<Tweet> replyTweets;
        private ICollection<Tweet> retweets;
        private ICollection<Report> reports;

        public Tweet()
        {
            this.favouritedBy = new HashSet<User>();
            this.replyTweets = new HashSet<Tweet>();
            this.retweets = new HashSet<Tweet>();
            this.reports = new HashSet<Report>();
        }

        [Key]
        public virtual int Id { get; set; }

        [Required]
        public virtual string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual int? RetweetedTweetId { get; set; }

        public virtual Tweet RetweetedTweet { get; set; }

        public virtual int? ReplyToId { get; set; }

        public virtual Tweet ReplyTo { get; set; }

        [Required]
        public virtual string Content { get; set; }

        [Required]
        public virtual DateTime TweetDate { get; set; }

        public virtual ICollection<User> FavouritedBy => this.favouritedBy;

        public virtual ICollection<Tweet> ReplyTweets => this.replyTweets;

        public virtual ICollection<Tweet> Retweets => this.retweets;

        public virtual ICollection<Report> Reports => this.reports;
    }
}