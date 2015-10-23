namespace Twitter.Data.UnitOfWork
{
    using Twitter.Data.Repositories;
    using Twitter.Models;

    public interface ITwittertData
    {
        IRepository<User> Users { get; }

        IRepository<Tweet> Tweets { get; }

        int SaveChanges();
    }
}