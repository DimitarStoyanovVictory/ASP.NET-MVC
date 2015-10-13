namespace MyTwitter.Models
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Twitt> favoriteTwitts;

        private ICollection<User> followers;

        private ICollection<User> following;

        private ICollection<Twitt> reTwitts;

        private ICollection<Twitt> twitts;

        private ICollection<Notification> notifications;

        private ICollection<Replay> replays;

        private ICollection<Report> reports;

        public User()
        {
            this.RegisteredOn = DateTime.Now;
            this.followers = new HashSet<User>();
            this.following = new HashSet<User>();
            this.reTwitts = new HashSet<Twitt>();
            this.twitts = new HashSet<Twitt>();
            this.favoriteTwitts = new HashSet<Twitt>();
            this.notifications = new HashSet<Notification>();
            this.reports = new HashSet<Report>();
            this.replays = new HashSet<Replay>();
        }

        public string FullName { get; set; }

        public DateTime RegisteredOn { get; set; }

        public virtual ICollection<User> Followers
        {
            get
            {
                return this.followers;
            }

            set
            {
                this.followers = value;
            }
        }

        public virtual ICollection<User> Following
        {
            get
            {
                return this.following;
            }

            set
            {
                this.following = value;
            }
        }

        public virtual ICollection<Twitt> Twitts
        {
             get
            {
                return this.twitts;
            }

            set
            {
                this.twitts = value;
            }
        }

        public virtual ICollection<Twitt> FavoriteTwitts
        {
            get
            {
                return this.favoriteTwitts;
            }

            set
            {
                this.favoriteTwitts = value;
            }
        }

        public virtual ICollection<Twitt> ReTwitts
        {
            get
            {
                return this.reTwitts;
            }

            set
            {
                this.reTwitts = value;
            }
        }

        public virtual ICollection<Notification> Notifications
        {
            get
            {
                return this.notifications;
            }

            set
            {
                this.notifications = value;
            }
        }

        public virtual ICollection<Replay> Replays
        {
            get
            {
                return this.replays;
            }

            set
            {
                this.replays = value;
            }
        }

        public virtual ICollection<Report> Reports
        {
            get
            {
                return this.reports;
            }

            set
            {
                this.reports = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}