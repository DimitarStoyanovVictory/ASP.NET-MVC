namespace Twitter.Data.UnitOfWork
{
    using Repositories;
    using Models;

    public interface ITwitterData
    {
        IRepository<User> Users { get; }

        IRepository<Tweet> Tweets { get; }

        IRepository<Message> Messages { get; }

        IRepository<Notification> Notifications { get; }

        int SaveChanges();
    }
}