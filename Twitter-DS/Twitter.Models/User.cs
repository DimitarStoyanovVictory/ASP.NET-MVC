﻿namespace Twitter.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;

    public class User : IdentityUser
    {
        private ICollection<User> followers;
        private ICollection<User> followedUsers;

        private ICollection<Tweet> tweets;

        private ICollection<Message> sentMessages;
        private ICollection<Message> receivedMessages;

        private ICollection<Notification> notifications;
        private ICollection<Tweet> favouritedTweets;

        private ICollection<Report> reports;

        public User()
        {
            this.followers = new HashSet<User>();
            this.followedUsers = new HashSet<User>();

            this.tweets = new HashSet<Tweet>();

            this.sentMessages = new HashSet<Message>();
            this.receivedMessages = new HashSet<Message>();

            this.notifications = new HashSet<Notification>();

            this.favouritedTweets = new HashSet<Tweet>();

            this.reports = new HashSet<Report>();
        }

        public string ProfileImageBase64 { get; set; }

        public string BackgroundImageBase64 { get; set; }

        public string Nickname { get; set; }

        public string AboutMe { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public virtual ICollection<User> Followers
        {
            get { return this.followers; }
        }

        public virtual ICollection<User> FollowedUsers
        {
            get { return this.followedUsers; }
        }

        public virtual ICollection<Tweet> Tweets
        {
            get { return this.tweets; }
        }

        public virtual ICollection<Message> ReceivedMessages
        {
            get { return this.receivedMessages; }
        }

        public virtual ICollection<Message> SentMessages
        {
            get { return this.sentMessages; }
        }

        public virtual ICollection<Notification> Notifications
        {
            get { return this.notifications; }
        }

        public virtual ICollection<Tweet> FavouritedTweets
        {
            get { return this.favouritedTweets; }
        }

        public virtual ICollection<Report> Reports
        {
            get { return this.reports; }
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