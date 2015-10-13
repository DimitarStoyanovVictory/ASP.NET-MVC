namespace MyTwitter.Data.Repositories
{
    using System.Data.Entity;
    using System.Linq;

    public class GeneralRepository<T> : IRepository<T> 
        where T : class 
    {
        public GeneralRepository()
            : this(new MyTwitterContext())
        {
        }

        public GeneralRepository(MyTwitterContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected MyTwitterContext Context { get; private set; }

        protected IDbSet<T> DbSet { get; private set; }

        public IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }

        public T Find(object id)
        {
            return this.DbSet.Find(id);
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public void Remove(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public T Remove(object id)
        {
            var entity = this.Find(id);

            this.ChangeState(entity, EntityState.Deleted);

            return entity;
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }

            entry.State = state;
        }
    }
}