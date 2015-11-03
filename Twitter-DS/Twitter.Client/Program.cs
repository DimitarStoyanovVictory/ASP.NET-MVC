//namespace Twitter.Client
//{
//    using System;
//    using System.Linq;
//    using Data;
//    using Models;

//    public class Program
//    {
//        private static void Main()
//        {
//            TwitterDbContext twitterDb = new TwitterDbContext();

//            // Users

//            InsertUsersInBase(twitterDb);

//            // Follwing table

//            InsertFollwersAndFollwingUsers(twitterDb);

//            // Tweets

//            InsertTweets(twitterDb);

//            // Edit profile

//            EditProfile(twitterDb);

//            // Users send messages to other users

//            SendMessages(twitterDb);

//            //Favourite tweets

//            FavouriteManyTweets(twitterDb);

//            //Retweet tweets

//            RetweetManyTweets(twitterDb);

//            //Report tweets as corrupt

//            ReportManyTweets(twitterDb);

//            //Shared to facebook tweet

//            ShareManyTweetsToFacebook(twitterDb);

//            //Reply tweets

//            ReplyManyTweets(twitterDb);

//            //Notifications

//            AddNotifications(twitterDb);
//        }

//        private static void InsertUsersInBase(TwitterDbContext twitterDb)
//        {
//            twitterDb.Users.Add(new User
//            {
//                UserName = "Dimitar",
//                CreatedOn = DateTime.Now,
//                Profile = new Profile
//                {
//                    Content = "Profile 1"
//                }
//            });

//            twitterDb.Users.Add(new User
//            {
//                UserName = "Angel",
//                CreatedOn = DateTime.Now,
//                Profile = new Profile
//                {
//                    Content = "Profile 2"
//                }
//            });

//            twitterDb.Users.Add(new User
//            {
//                UserName = "Kiro",
//                CreatedOn = DateTime.Now,
//                Profile = new Profile
//                {
//                    Content = "Profile 3"
//                }
//            });

//            twitterDb.Users.Add(new User
//            {
//                UserName = "Biliana",
//                CreatedOn = DateTime.Now,
//                Profile = new Profile
//                {
//                    Content = "Profile 4"
//                }
//            });

//            twitterDb.Users.Add(new User
//            {
//                UserName = "Ivan",
//                CreatedOn = DateTime.Now,
//                Profile = new Profile
//                {
//                    Content = "Profile 5"
//                }
//            });

//            twitterDb.SaveChanges();
//        }

//        private static void InsertFollwersAndFollwingUsers(TwitterDbContext twitterDb)
//        {
//            var users = twitterDb.Users.ToList();

//            users[3].Followings.Add(users[0]);
//            users[0].Followers.Add(users[3]);
//            users[3].Followings.Add(users[1]);
//            users[1].Followers.Add(users[3]);
//            users[3].Followings.Add(users[2]);
//            users[2].Followers.Add(users[3]);

//            twitterDb.SaveChanges();
//        }

//        private static void InsertTweets(TwitterDbContext twitterDb)
//        {
//            var users = twitterDb.Users.ToList();

//            users[0].Tweets.Add(new Tweet { Content = "Tweet one", CreatedOn = DateTime.Now});
//            users[0].Tweets.Add(new Tweet { Content = "Tweet two", CreatedOn = DateTime.Now});
//            users[0].Tweets.Add(new Tweet { Content = "Tweet tree", CreatedOn = DateTime.Now});

//            twitterDb.SaveChanges();
//        }

//        private static void EditProfile(TwitterDbContext twitterDb)
//        {
//            var users = twitterDb.Users.ToList();
//            users[0].Profile.Content = "Changed";

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

//            twitterDb.SaveChanges();
//        }

//        private static void FavouriteManyTweets(TwitterDbContext twitterDb)
//        {
//            var users = twitterDb.Users.ToList();
//            var tweets = twitterDb.Tweets.ToList();

//            users[0].FavouriteTweets.Add(tweets[0]);
//            users[0].FavouriteTweets.Add(tweets[1]);
//            users[0].FavouriteTweets.Add(tweets[2]);

//            twitterDb.SaveChanges();
//        }

//        private static void RetweetManyTweets(TwitterDbContext twitterDb)
//        {
//            var users = twitterDb.Users.ToList();
//            var tweets = twitterDb.Tweets.ToList();

//            users[0].ReTweets.Add(tweets[0]);
//            users[0].ReTweets.Add(tweets[1]);
//            users[0].ReTweets.Add(tweets[2]);

//            twitterDb.SaveChanges();
//        }

//        private static void ReportManyTweets(TwitterDbContext twitterDb)
//        {
//            var users = twitterDb.Users.ToList();
//            var tweets = twitterDb.Tweets.ToList();

//            users[0].ReportedTweets.Add(tweets[0]);
//            users[0].ReportedTweets.Add(tweets[1]);
//            users[0].ReportedTweets.Add(tweets[2]);

//            twitterDb.SaveChanges();
//        }

//        private static void ShareManyTweetsToFacebook(TwitterDbContext twitterDb)
//        {
//            var users = twitterDb.Users.ToList();
//            var tweets = twitterDb.Tweets.ToList();

//            users[0].SharedTweetsToFacebook.Add(tweets[0]);
//            users[0].SharedTweetsToFacebook.Add(tweets[1]);
//            users[0].SharedTweetsToFacebook.Add(tweets[2]);

//            twitterDb.SaveChanges();
//        }

//        private static void ReplyManyTweets(TwitterDbContext twitterDb)
//        {
//            var users = twitterDb.Users.ToList();
//            var tweets = twitterDb.Tweets.ToList();

//            users[0].ReplyTweets.Add(tweets[0]);
//            users[0].ReplyTweets.Add(tweets[1]);
//            users[0].ReplyTweets.Add(tweets[2]);

//            twitterDb.SaveChanges();
//        }

//        private static void AddNotifications(TwitterDbContext twitterDb)
//        {
//            var users = twitterDb.Users.ToList();

//            users[0].Notifications.Add(new Notification { Content = "Notification 1"});
//            users[0].Notifications.Add(new Notification { Content = "Notification 2"});
//            users[0].Notifications.Add(new Notification { Content = "Notification 3"});

//            twitterDb.SaveChanges();
//        }
//    }
//}