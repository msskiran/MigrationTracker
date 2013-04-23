
using System;
using System.Data.Entity;

namespace NewMigrationTracker.DataAccess.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private bool disposed = false;
        private readonly NewMigrationTrackerContext dbContext;
        private IDbSet<T> dbSet;

        protected BaseRepository(NewMigrationTrackerContext context)
        {
            dbContext = context;
            dbSet = context.Set<T>();
        }

        public T Get(T t)
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<T> GetMany(System.Func<T, bool> where)
        {
            throw new System.NotImplementedException();
        }

        public T Add(T t)
        {
            return dbSet.Add(t);
            SaveToDB();
        }

        public T Update(T t)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(T t)
        {
            throw new System.NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public T GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



        public void SaveToDB()
        {
            dbContext.SaveChanges();
        }
    }
}