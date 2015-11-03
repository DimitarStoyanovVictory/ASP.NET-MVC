namespace Twitter.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class FavouriteTweet : Entity
    {
        [ForeignKey("Tweet")]
        public virtual int TweetId { get; set; }
        public virtual Tweet Tweet { get; set; }

        [ForeignKey("User")]
        public virtual int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
