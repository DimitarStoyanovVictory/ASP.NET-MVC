namespace Twitter.Data.Repositories
{
    using System.Data.Entity;
    using System.Linq;

    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly IDbSet<T> _set;

        public GenericRepository(DbContext context)
        {
            this._context = context;
            this._set = _context.Set<T>();
        } 

        public IQueryable<T> All()
        {
            return this._set.AsQueryable();
        }

        public T Find(object id)
        {
            return this._set.Find(id);
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public T Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
            return entity;
        }

        public T Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
            return entity;
        }

        public T Delete(object id)
        {
            var entity = this.Find(id);
            this.Delete(entity);
            return entity;
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this._context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this._set.Attach(entity);
            }

            entry.State = state;
        }
    }

}
