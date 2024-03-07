using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace vlife.Data
{
    public class GenericRepository<T> : IDisposable where T : class
    {
        private bool _disposed;
        protected readonly Context Context;
        private DbSet<T> Entities { get; set; }

        public GenericRepository(Context contexto)
        {
            Context = contexto;
            Entities = contexto.Set<T>();
        }

        private IQueryable<T> Query(params Expression<Func<T, object>>[] includes)
        {
            var query = Entities.AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                    if (include != null)
                        query = query.Include(include);
            }
            return query;
        }

        public T Get(Expression<Func<T, bool>> filters, string thenIncludes = "", params Expression<Func<T, object>>[] includes)
        {
            var query = Query(includes).AsNoTracking();

            if (thenIncludes.Equals("All"))
            {
                query = this.AddDefaultIncludes(query);
            }

            if (filters != null)
                return query.Where(filters).SingleOrDefault();

            return query.SingleOrDefault();
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> filters = null,
            params Expression<Func<T, object>>[] includes)
        {
            var query = Query(includes).AsNoTracking();

            if (filters != null)
                query = query.Where(filters);

            return query;
        }

        public virtual IQueryable<T> AddDefaultIncludes(IQueryable<T> query)
        {
            return query;
        }

        public List<T> GetAll(Expression<Func<T, bool>> filters = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> sortedBy = null,
            params Expression<Func<T, object>>[] includes)
        {
            var query = Query(includes).AsNoTracking();

            if (filters != null)
                query = query.Where(filters);

            if (sortedBy != null)
                query = sortedBy(query);

            return query.ToList();
        }

        public T Add(T Entity)
        {
            if (Entity == null)
                throw new ArgumentNullException(typeof(T).FullName);

            var retorno = Entities.Add(Entity);

            return retorno.Entity;
        }

        public void AddRange(List<T> Entity)
        {
            if (Entity == null || Entity.Count == 0)
                throw new ArgumentNullException(typeof(T).FullName);

            Entities.AddRange(Entity);
        }

        public void Salvar()
        {
            Context.SaveChanges();
        }

        public void CreateTransaction()
        {
            Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            Context.Database.CommitTransaction();
        }

        public void Rollback()
        {
            Context.Database.RollbackTransaction();
        }

        public bool InTransaction()
        {
            return Context.Database.CurrentTransaction != null;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                Context.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
