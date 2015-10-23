namespace Twitter.App.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using Twitter.Models;

    public class TweetViewModel
    {
        public TweetViewModel(Tweet tweet)
        {
            this.Id = tweet.Id;
            this.Content = tweet.Content;
            this.PublishDate = tweet.PublishDate;
            this.Owner = new UserViewModel(tweet.Owner);
            this.IsReported = tweet.IsReported;
            this.RetweetsCount = tweet.Retweeters.Count;
            this.FavoritesCount = tweet.FavoritedUsers.Count;
            this.Replies = new List<RepliesViewModel>();
            foreach (var reply in tweet.Replies)
            {
                this.Replies.Add(new RepliesViewModel(reply));
            }
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate{ get; set; }

        public UserViewModel Owner { get; set; }

        public ICollection<RepliesViewModel> Replies { get; set; }

        public bool IsReported{ get; set; }

        public int  RetweetsCount{ get; set; }

        public int FavoritesCount{ get; set; }
    }
}