namespace MyTwitter.Client
{
    using System;
    using Data;
    using Models;

    class Program
    {
        static void Main()
        {
            MyTwitterContext twitterDB = new MyTwitterContext();

            var userFirst = new User
            {
                FullName = "Dimitar",
                Email = "d.victory@gmail.com",
                EmailConfirmed = true,
                PasswordHash = "123",
                SecurityStamp = "123",
                PhoneNumber = "123",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = true,
                LockoutEndDateUtc = DateTime.Now,
                LockoutEnabled = true,
                AccessFailedCount = 1,
                UserName = "D.Stoyanov"
            };

            twitterDB.Users.Add(userFirst);
            //twitterDB.Twitts.Add(new Twitt
            //{
            //    PublishedOn = DateTime.Now,
            //    Text = "Hello i am 26",
            //    AuthorId = userFirst.Id,
            //    Author = userFirst
            //});

            //twitterDB.Twitts.Add(new Twitt
            //{
            //    PublishedOn = DateTime.Now,
            //    Text = "Hello i am 25",
            //    AuthorId = userFirst.Id,
            //    Author = userFirst
            //});


            //twitterDB.Twitts.Add(new Twitt
            //{
            //    PublishedOn = DateTime.Now,
            //    Text = "Hello i am 24",
            //    AuthorId = userFirst.Id,
            //    Author = userFirst
            //});

            twitterDB.SaveChanges();
        }
    }
}
