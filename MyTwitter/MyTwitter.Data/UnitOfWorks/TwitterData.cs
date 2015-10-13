namespace MyTwitter.Data.UnitOfWorks
{
    using System;
    using System.Collections.Generic;
    using Repositories;
    using Models;

    public class TwitterData : IData
    {
        private readonly MyTwitterContext context;

        private readonly IDictionary<Type, object> repositories;

        public TwitterData()
            : this(new MyTwitterContext())
        {
        }

        public TwitterData(MyTwitterContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Twitt> Twitts
        {
            get
            {
                return this.GetRepository<Twitt>();
            }
        }

        public IRepository<Notification> Notifications
        {
            get
            {
                return this.GetRepository<Notification>();
            }
        }

        public IRepository<Replay> Replays
        {
            get
            {
                return this.GetRepository<Replay>();
            }
        }

        public IRepository<Report> Reports
        {
            get
            {
                return this.GetRepository<Report>();
            }
        }

        public IRepository<Message> Messages
        {
            get
            {
                return this.GetRepository<Message>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() 
            where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GeneralRepository<T>);
                this.repositories.Add(
                    typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}