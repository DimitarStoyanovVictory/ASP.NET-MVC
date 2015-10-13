namespace Twitter.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class TwitterDbContext : DbContext, ITwitterData
    {
        public TwitterDbContext()
            : base("name=TwitterDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TwitterDbContext, Configuration>());
        }

        public TwitterDbContext TwitterData { get; }

        public DbSet<User> Users { get; set; }

        public DbSet<Twiit> Tweets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Follwed and Following users

            modelBuilder.Entity<User>()
                .HasMany(u => u.Followings)
                .WithMany(u => u.Followers)
                .Map(m =>
                {
                    m.MapLeftKey("FollowedId");
                    m.MapRightKey("FollowerId");
                    m.ToTable("Follow");
                });

            // Profile

            //modelBuilder.Entity<Profile>()
            //    .HasKey(p => p.UserId);

            //modelBuilder.Entity<User>()
            //    .HasRequired(u => u.Profile)
            //    .WithRequiredPrincipal(p => p.User);

            // Tweets

            modelBuilder.Entity<Twiit>()
                .HasRequired(t => t.User)
                .WithMany(u => u.Tweets)
                .HasForeignKey(u => u.UserId)
                .WillCascadeOnDelete(false);

            // Messages

            modelBuilder.Entity<Message>()
                .HasRequired(m => m.User)
                .WithMany(u => u.Messages)
                .HasForeignKey(u => u.UserId)
                .WillCascadeOnDelete(false);

            // FavouriteTweets

            modelBuilder.Entity<User>()
                .HasMany(u => u.FavouriteTweets)
                .WithMany(t => t.UserTweetFavours)
                .Map(m =>
                {
                    m.MapLeftKey("TweetId");
                    m.MapRightKey("UserId");
                    m.ToTable("FavouriteTweets");
                });

            // ReTweets

            modelBuilder.Entity<User>()
                .HasMany(u => u.ReTweets)
                .WithMany(t => t.UserReTweets)
                .Map(m =>
                {
                    m.MapLeftKey("TweetId");
                    m.MapRightKey("UserId");
                    m.ToTable("ReTweets");
                });

            // ReportedTweets

            modelBuilder.Entity<User>()
                .HasMany(u => u.ReportedTweetsAsCorrupt)
                .WithMany(t => t.UserReportedTweetsAsCorrupt)
                .Map(m =>
                {
                    m.MapLeftKey("TweetId");
                    m.MapRightKey("UserId");
                    m.ToTable("ReportedTweetsAsCorrupt");
                });

            // ReportedTweetsToFacebook

            modelBuilder.Entity<User>()
                .HasMany(u => u.ReportedTweetsToFacebook)
                .WithMany(t => t.UserReportedTweetsToFacebook)
                .Map(m =>
                {
                    m.MapLeftKey("TweetId");
                    m.MapRightKey("UserId");
                    m.ToTable("ReportedTweetsToFacebook");
                });

            // Tweets and ReTweets

            modelBuilder.Entity<User>()
                .HasMany(u => u.ReplyTweets)
                .WithMany(t => t.UserReplyTweets)
                .Map(m =>
                {
                    m.MapLeftKey("TweetId");
                    m.MapRightKey("UserId");
                    m.ToTable("ReplyTweets");
                });

            // Notifications

            modelBuilder.Entity<Notification>()
                .HasRequired(m => m.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(u => u.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}