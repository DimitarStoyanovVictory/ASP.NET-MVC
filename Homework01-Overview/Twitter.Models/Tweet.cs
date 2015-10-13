namespace Twitter.Models
{
    using System.Collections.Generic;

    public class Tweet
    {
        private HashSet<User> _userTweetFavour;
        private HashSet<User> _userReTweets;
        private HashSet<User> _userReportedTweetsAsCorrupt;
        private HashSet<User> _reportedTweeetsToFacebook;
        private HashSet<User> _replayTweets; 

        public virtual int Id { get; set; }

        public virtual string Content { get; set; }

        public virtual string Url { get; set; }

        public virtual int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<User> UserTweetFavours => _userTweetFavour ?? new HashSet<User>();

        public virtual ICollection<User> UserReTweets => _userReTweets ?? new HashSet<User>();

        public virtual ICollection<User> UserReportedTweetsAsCorrupt => _userReportedTweetsAsCorrupt ?? new HashSet<User>();

        public virtual ICollection<User> UserReportedTweetsToFacebook
            => _reportedTweeetsToFacebook ?? new HashSet<User>();

        public virtual ICollection<User> UserReplyTweets => _replayTweets ?? (_replayTweets = new HashSet<User>());
    }
}

//namespace Twitter.Models
//{
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations.Schema;

//    public class Tweet : Entity
//    {
//        public virtual string Content { get; set; }
//        [ForeignKey("Tweeter")]
//        public virtual int TweeterId { get; set; }

//        public virtual User Tweeter { get; set; }

//        private HashSet<FavouriteTweet> _userTweetFavour;
//        public virtual ICollection<FavouriteTweet> UserTweetFavours => _userTweetFavour ?? new HashSet<FavouriteTweet>();
//    }
//}
