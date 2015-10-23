namespace Twitter.Models
{
    using System.Threading.Tasks;
    using System.Security.Claims;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using Enums;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<User> followers;
        private ICollection<User> followedUsers;
        private ICollection<Tweet> favoriteTweets;
        private ICollection<Tweet> tweets; 
        private ICollection<Tweet> retweets;
        private ICollection<Message> sentMessageses;
        private ICollection<Message> recievedMessages;

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public User()
        {
            this.followers = new HashSet<User>();
            this.followedUsers = new HashSet<User>();
            this.favoriteTweets = new HashSet<Tweet>();
            this.retweets = new HashSet<Tweet>();
            this.sentMessageses = new HashSet<Message>();
            this.recievedMessages = new HashSet<Message>();
            this.retweets = new HashSet<Tweet>();
            this.tweets = new HashSet<Tweet>();
        }

        [Required]
        public int Age { get; set; }

        [Required]
        public Sex Sex { get; set; }

        public virtual ICollection<User> Followers
        {
            get { return this.followers; }
            set { this.followers = value; }
        }

        public virtual ICollection<User> FollowedUsers
        {
            get { return this.followedUsers; }
            set { this.followedUsers = value; }
        }

        public virtual ICollection<Tweet> FavoriteTweets
        {
            get { return this.favoriteTweets; }
            set { this.favoriteTweets = value; }
        }

        public virtual ICollection<Tweet> Retweets
        {
            get { return this.retweets; }
            set { this.retweets = value; }
        }

        public virtual ICollection<Message> SentMessageses
        {
            get { return this.sentMessageses; }
            set { this.sentMessageses = value; }
        }

        public virtual ICollection<Message> RecievedMessages
        {
            get { return this.recievedMessages; }
            set { this.recievedMessages = value; }
        }

        public virtual ICollection<Tweet> Tweets
        {
            get { return this.tweets; }
            set { this.tweets = value; }
        } 
    }
}
