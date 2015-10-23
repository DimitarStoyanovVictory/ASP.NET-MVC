namespace Twitter.App.Models.ViewModels
{
    using System.Collections.Generic;
    using Twitter.Models;

    public class UserProfileViewModel
    {
        public UserProfileViewModel(User user,
            ICollection<Tweet> tweets,
            ICollection<User> followers,
            ICollection<User> following,
            ICollection<Tweet> favorites)
        {
            this.User = new UserViewModel(user);
            this.Tweets = new HashSet<TweetViewModel>();
            foreach (var tweet in tweets)
            {
                this.Tweets.Add(new TweetViewModel(tweet));
            }

            this.Followers = new HashSet<UserViewModel>();
            foreach (var follower in followers)
            {
                this.Followers.Add(new UserViewModel(follower));
            }

            this.Following = new HashSet<UserViewModel>();
            foreach (var followed in following)
            {
                this.Following.Add(new UserViewModel(followed));
            }

            this.Favorites = new HashSet<TweetViewModel>();
            foreach (var tweet in favorites)
            {
                this.Favorites.Add(new TweetViewModel(tweet));
            }
        }

        public string Id { get; set; }

        public ICollection<TweetViewModel> Tweets { get; set; }

        public ICollection<UserViewModel> Followers { get; set; }

        public ICollection<UserViewModel> Following { get; set; }

        public ICollection<TweetViewModel> Favorites { get; set; }

        public UserViewModel User { get; set; }
    }
}