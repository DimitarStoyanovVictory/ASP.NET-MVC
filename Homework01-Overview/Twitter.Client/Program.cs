namespace Twitter.Client
{
    using System;
    using System.Linq;
    using Data;
    using Models;

    public class Program
    {
        private static void Main()
        {
            TwitterDbContext twitterDb = new TwitterDbContext();

            // Users

            InsertUsersInBase(twitterDb);

            // Follwing table

            InsertFollwersAndFollwingUsers(twitterDb);

            // Tweets

            InsertTweets(twitterDb);

            // Edit profile

            EditProfile(twitterDb);

            // Users send messages to other users

            SendMessages(twitterDb);

            //Favourite tweets

            FavouriteManyTweets(twitterDb);

            //Retweet tweets

            RetweetManyTweets(twitterDb);

            //Report tweets as corrupt

            ReportManyTweetsAsCorrupt(twitterDb);

            //Shared to facebook tweet

            ReportManyTweetsToFacebook(twitterDb);

            //Reply tweets

            ReplyManyTweets(twitterDb);

            //Notifications

            AddNotifications(twitterDb);
        }

        private static void InsertUsersInBase(TwitterDbContext twitterDb)
        {
            twitterDb.Users.Add(new User
            {
                Name = "Dimitar",
                Profile = new Profile
                {
                    Content = "Profile 1"
                }
            });
                
            twitterDb.Users.Add(new User
            {
                Name = "Angel",
                Profile = new Profile
                {
                    Content = "Profile 2"
                }
            });

            twitterDb.Users.Add(new User
            {
                Name = "Kiro",
                Profile = new Profile
                {
                    Content = "Profile 3"
                }
            });

            twitterDb.Users.Add(new User
            {
                Name = "Biliana",
                Profile = new Profile
                {
                    Content = "Profile 4"
                }
            });

            twitterDb.Users.Add(new User
            {
                Name = "Ivan",
                Profile = new Profile
                {
                    Content = "Profile 5"
                }
            });

            twitterDb.SaveChanges();
        }

        private static void InsertFollwersAndFollwingUsers(TwitterDbContext twitterDb)
        {
            var users = twitterDb.Users.ToList();

            users[3].Followings.Add(users[0]);
            users[0].Followers.Add(users[3]);
            users[3].Followings.Add(users[1]);
            users[1].Followers.Add(users[3]);
            users[3].Followings.Add(users[2]);
            users[2].Followers.Add(users[3]);

            twitterDb.SaveChanges();
        }

        private static void InsertTweets(TwitterDbContext twitterDb)
        {
            var users = twitterDb.Users.ToList();

            users[0].Tweets.Add(new Tweet());
            users[0].Tweets.Add(new Tweet());
            users[0].Tweets.Add(new Tweet());

            twitterDb.SaveChanges();
        }

        private static void EditProfile(TwitterDbContext twitterDb)
        {
            var users = twitterDb.Users.ToList();
            users[0].Profile.Content = "Changed";

            twitterDb.SaveChanges();
        }

        private static void SendMessages(TwitterDbContext twitterDb)
        {
            var users = twitterDb.Users.ToList();

            users[0].Messages.Add(new Message
            {
                Title = "Parfume",
                Content = "Farenhaint my favorite parfume",
                SentDate = DateTime.Now,
            });

            twitterDb.SaveChanges();
        }

        private static void FavouriteManyTweets(TwitterDbContext twitterDb)
        {
            var users = twitterDb.Users.ToList();
            var tweets = twitterDb.Tweets.ToList();

            users[0].FavouriteTweets.Add(tweets[0]);
            users[0].FavouriteTweets.Add(tweets[1]);
            users[0].FavouriteTweets.Add(tweets[2]);

            twitterDb.SaveChanges();
        }

        private static void RetweetManyTweets(TwitterDbContext twitterDb)
        {
            var users = twitterDb.Users.ToList();
            var tweets = twitterDb.Tweets.ToList();

            users[0].ReTweets.Add(tweets[0]);
            users[0].ReTweets.Add(tweets[1]);
            users[0].ReTweets.Add(tweets[2]);

            twitterDb.SaveChanges();
        }

        private static void ReportManyTweetsAsCorrupt(TwitterDbContext twitterDb)
        {
            var users = twitterDb.Users.ToList();
            var tweets = twitterDb.Tweets.ToList();

            users[0].ReportedTweetsAsCorrupt.Add(tweets[0]);
            users[0].ReportedTweetsAsCorrupt.Add(tweets[1]);
            users[0].ReportedTweetsAsCorrupt.Add(tweets[2]);

            twitterDb.SaveChanges();
        }

        private static void ReportManyTweetsToFacebook(TwitterDbContext twitterDb)
        {
            var users = twitterDb.Users.ToList();
            var tweets = twitterDb.Tweets.ToList();

            users[0].ReportedTweetsToFacebook.Add(tweets[0]);
            users[0].ReportedTweetsToFacebook.Add(tweets[1]);
            users[0].ReportedTweetsToFacebook.Add(tweets[2]);

            twitterDb.SaveChanges();
        }

        private static void ReplyManyTweets(TwitterDbContext twitterDb)
        {
            var users = twitterDb.Users.ToList();
            var tweets = twitterDb.Tweets.ToList();

            users[0].ReplyTweets.Add(tweets[0]);
            users[0].ReplyTweets.Add(tweets[1]);
            users[0].ReplyTweets.Add(tweets[2]);

            twitterDb.SaveChanges();    
        }

        private static void AddNotifications(TwitterDbContext twitterDb)
        {
            var users = twitterDb.Users.ToList();

            users[0].Notifications.Add(new Notification { Content = "Notification 1"});
            users[0].Notifications.Add(new Notification { Content = "Notification 2"});
            users[0].Notifications.Add(new Notification { Content = "Notification 3"});

            twitterDb.SaveChanges();
        }
    }
}

//namespace Twitter.Client
//{
//    using System;
//    using System.Data.Entity;
//    using System.Linq;
//    using Data;
//    using Models;

//    public class Program
//    {
//        private static User _dimitar = new User() { Name = "Dimitar", Profile = new Profile() };
//        private static User _angel = new User() { Name = "Angel", Profile = new Profile() };
//        static void Main()
//        {
//            TwitterDbContext twitterDb = new TwitterDbContext();

//            InsertUsersInBase(twitterDb);

//            InsertFollwersAndFollwingUsers(twitterDb);

//            // Tweets

//            InsertTweets(twitterDb);

//            // Edit profile

//            EditProfile(twitterDb);

//            // Users send messages to other users

//            SendMessages(twitterDb);

//            // Favourite tweets

//            FavouriteManyTweets(twitterDb);

//            // Retweet tweets

//            //RetweetManyTweets(twitterDb);

//            twitterDb.SaveChanges();
//        }

//        private static void InsertUsersInBase(TwitterDbContext twitterDb)
//        {

//            twitterDb.Users.Add(_dimitar);

//            twitterDb.Users.Add(_angel);

//            twitterDb.SaveChanges();
//        }

//        private static void InsertFollwersAndFollwingUsers(TwitterDbContext twitterDb)
//        {
//            _dimitar = twitterDb.Users.FirstOrDefault(x => x.Name == _dimitar.Name);
//            _angel = twitterDb.Users.FirstOrDefault(x => x.Name == _angel.Name);
//            _dimitar.Followers.Add(_angel);

//            twitterDb.Entry(_dimitar).State = EntityState.Modified;
//            twitterDb.SaveChanges();
//        }

//        private static void InsertTweets(TwitterDbContext twitterDb)
//        {
//            _dimitar.Tweets.Add(new Tweet() { Content = "asd", TweeterId = _dimitar.Id });
//            _dimitar.Tweets.Add(new Tweet() { Content = "zxc", TweeterId = _dimitar.Id });
//            _dimitar.Tweets.Add(new Tweet() { Content = "qwe", TweeterId = _dimitar.Id });
//            twitterDb.Entry(_dimitar).State = EntityState.Modified;
//            twitterDb.SaveChanges();
//        }

//        private static void EditProfile(TwitterDbContext twitterDb)
//        {
//            var users = twitterDb.Users.ToList();
//            users[0].Profile.Content = "Changed";
//            twitterDb.Entry(users[0]).State = EntityState.Modified;
//            twitterDb.SaveChanges();
//        }

//        private static void SendMessages(TwitterDbContext twitterDb)
//        {
//            var users = twitterDb.Users.ToList();

//            users[0].Messages.Add(new Message
//            {
//                Title = "Parfume",
//                Content = "Farenhaint my favorite parfume",
//                SentDate = DateTime.Now,
//            });

//            twitterDb.Entry(users[0]).State = EntityState.Modified;
//            twitterDb.SaveChanges();
//        }

//        private static void FavouriteManyTweets(TwitterDbContext twitterDb)
//        {
//            var dimitar = twitterDb.Users.FirstOrDefault(x => x.Name == "Dimitar");

//            dimitar.FavouriteTweets.Add(new FavouriteTweet() { UserId = dimitar.Id, TweetId = 1 });
//            dimitar.FavouriteTweets.Add(new FavouriteTweet() { UserId = dimitar.Id, TweetId = 2 });
//            dimitar.FavouriteTweets.Add(new FavouriteTweet() { UserId = dimitar.Id, TweetId = 3 });
//            twitterDb.Entry(dimitar).State = EntityState.Modified;
//            twitterDb.SaveChanges();
//        }

//        //private static void RetweetManyTweets(TwitterDbContext twitterDb)
//        //{
//        //    var users = twitterDb.Users.ToList();

//        //    users[0].ReTweets.Add(new Tweet());
//        //    users[0].ReTweets.Add(new Tweet());
//        //    users[0].ReTweets.Add(new Tweet());

//        //    twitterDb.SaveChanges();
//        //}
//    }
//}
