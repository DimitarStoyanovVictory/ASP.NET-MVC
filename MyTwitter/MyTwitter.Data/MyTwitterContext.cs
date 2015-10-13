namespace MyTwitter.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;

    public class MyTwitterContext : IdentityDbContext<User>
    {
        public MyTwitterContext()
            : base("MyTwitter")
        {
        }

        public virtual IDbSet<Twitt> Twitts { get; set; }

        public virtual IDbSet<Replay> Replays { get; set; }

        public virtual IDbSet<Report> Reports { get; set; }

        public virtual IDbSet<Message> Messages { get; set; }

        public static MyTwitterContext Create()
        {
            return new MyTwitterContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<User>()
                .HasMany(t => t.Twitts);

            modelBuilder.Entity<User>()
                .HasMany(u => u.FavoriteTwitts)
                .WithMany(u => u.UsersFavorites)
                .Map(m =>
                    {
                        m.MapLeftKey("AuthorId");
                        m.MapRightKey("TwittId");
                        m.ToTable("UsersFavoritesTwitts");
                    });

            modelBuilder.Entity<User>()
                .HasMany(u => u.ReTwitts)
                .WithMany(u => u.UsersReTwittes)
                .Map(m =>
                {
                    m.MapLeftKey("AuthorId");
                    m.MapRightKey("ReTwittId");
                    m.ToTable("UsersReTwitts");
                });

            modelBuilder.Entity<User>()
                .HasMany(u => u.Followers)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FollowerId");
                    m.ToTable("UsersFollowers");
                });

            modelBuilder.Entity<User>()
                .HasMany(u => u.Following)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FollowingId");
                    m.ToTable("UsersFollowings");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}