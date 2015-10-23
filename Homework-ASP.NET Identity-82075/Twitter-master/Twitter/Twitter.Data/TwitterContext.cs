namespace Twitter.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class TwitterContext : IdentityDbContext<User>
    {
        public TwitterContext()
            : base("TwitterContext")
        {
        }

        public static TwitterContext Create()
        {
            return new TwitterContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<User>()
                .HasMany<Tweet>(u => u.FavoriteTweets)
                .WithMany(t => t.FavoritedUsers)
                .Map(cs =>
                {
                    cs.MapLeftKey("OwnerId");
                    cs.MapRightKey("TweetId");
                    cs.ToTable("FavoriteTweets");
                });

            modelBuilder.Entity<User>()
                .HasMany<User>(u => u.Followers)
                .WithMany(t => t.FollowedUsers)
                .Map(cs =>
                {
                    cs.MapLeftKey("FollowedUserId");
                    cs.MapRightKey("Follower");
                    cs.ToTable("Followers");
                });

            modelBuilder.Entity<User>()
                .HasMany<Tweet>(t => t.Retweets)
                .WithMany(u => u.Retweeters)
                .Map(cs =>
                {
                    cs.MapLeftKey("UserId");
                    cs.MapRightKey("TweetId");
                    cs.ToTable("Retweets");
                });

            modelBuilder.Entity<Message>()
                .HasRequired(u => u.Sender)
                .WithMany(u => u.SentMessageses);

            modelBuilder.Entity<Message>()
                .HasRequired(u => u.Reciever)
                .WithMany(u => u.RecievedMessages);

            modelBuilder.Entity<Tweet>()
                .HasRequired(u => u.Owner)
                .WithMany(u => u.Tweets);

        }

        public IDbSet<Tweet> Tweets { get; set; }

        public IDbSet<Notifications> Notifications { get; set; }

        public IDbSet<Message> Messages { get; set; }

        public IDbSet<Reply> Replies { get; set; }

    }
}
