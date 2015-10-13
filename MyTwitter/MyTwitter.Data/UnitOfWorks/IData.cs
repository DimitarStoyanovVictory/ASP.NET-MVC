namespace MyTwitter.Data.UnitOfWorks
{
    using Repositories;
    using Models;

    public interface IData
    {
        IRepository<User> Users { get; }

        IRepository<Twitt> Twitts { get; }

        IRepository<Notification> Notifications { get; }

        IRepository<Replay> Replays { get; }

        IRepository<Report> Reports { get; }

        IRepository<Message> Messages { get; }

        void SaveChanges();
    }
}