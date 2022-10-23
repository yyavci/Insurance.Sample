using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Sample.Data
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private DbContext _dataContext;
        private readonly IDbSet<T> _dbSet;

        public RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            _dbSet = DataContext.Set<T>();
        }
        protected IDatabaseFactory DatabaseFactory
        {
            get; private set;
        }
        protected DbContext DataContext
        {
            get { return _dataContext ?? (_dataContext = DatabaseFactory.Get()); }
        }

        public void Add(T value)
        {
            _dbSet.Add(value);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            T entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }
        public void Delete(T Entity)
        {
            if (_dataContext.Entry(Entity).State == EntityState.Detached)
            {
                _dbSet.Attach(Entity);
            }
            _dbSet.Remove(Entity);
            _dataContext.SaveChanges();
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public void Update(T value)
        {
            _dbSet.Attach(value);
            _dataContext.Entry(value).State = EntityState.Modified;
            _dataContext.SaveChanges();

        }
        
    }
}
