namespace Twitter.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        private HashSet<User> _followers;
        private HashSet<User> _followings;
        private HashSet<Tweet> _tweets;
        private HashSet<Message> _messages;
        private HashSet<Tweet> _favouriteTweets;
        private HashSet<Tweet> _reTweets;
        private HashSet<Tweet> _reportedTweetsAsCorrupt;
        private HashSet<Tweet> _reportedTweetsToFacebook;
        private HashSet<Tweet> _replyTweets;
        private HashSet<Notification> _notifications; 

        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public virtual string Name { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual ICollection<User> Followers => _followers ?? (_followers = new HashSet<User>());

        public virtual ICollection<User> Followings => _followings ?? (_followings = new HashSet<User>());

        public virtual ICollection<Tweet> Tweets => _tweets ?? (_tweets = new HashSet<Tweet>());

        public virtual ICollection<Message> Messages => _messages ?? (_messages = new HashSet<Message>());

        public virtual ICollection<Tweet> FavouriteTweets => _favouriteTweets ?? (_favouriteTweets = new HashSet<Tweet>());

        public virtual ICollection<Tweet> ReTweets => _reTweets ?? (_reTweets = new HashSet<Tweet>());

        public virtual ICollection<Tweet> ReportedTweetsAsCorrupt => _reportedTweetsAsCorrupt ?? (_reportedTweetsAsCorrupt = new HashSet<Tweet>());

        public virtual ICollection<Tweet> ReportedTweetsToFacebook => _reportedTweetsToFacebook ?? (_reportedTweetsToFacebook = new HashSet<Tweet>());

        public virtual ICollection<Tweet> ReplyTweets => _replyTweets ?? (_replyTweets = new HashSet<Tweet>());

        public virtual ICollection<Notification> Notifications => _notifications ?? (_notifications = new HashSet<Notification>());
    }
}

//namespace Twitter.Models
//{
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;

//    public class User : Entity
//    {
//        [Required]
//        [MaxLength(20)]
//        public virtual string Name { get; set; }

//        public virtual Profile Profile { get; set; }

//        private HashSet<User> _followers;
//        public virtual ICollection<User> Followers => _followers ?? new HashSet<User>();

//        private HashSet<User> _followings;
//        public virtual ICollection<User> Followings => _followings ?? new HashSet<User>();

//        private HashSet<Tweet> _tweets;
//        public virtual ICollection<Tweet> Tweets => _tweets ?? new HashSet<Tweet>();

//        private HashSet<FavouriteTweet> _favouriteTweets;
//        public virtual ICollection<FavouriteTweet> FavouriteTweets => _favouriteTweets ?? new HashSet<FavouriteTweet>();

//        private HashSet<Message> _messages;
//        public virtual ICollection<Message> Messages => _messages ?? new HashSet<Message>();

//    }
//}
