
using NewMigrationTracker.DataAccess.Repositories;

namespace NewMigrationTracker_Services.Interfaces
{
    public abstract class BaseService<T> : IService<T> where T : class
    {
        protected IRepository<T> repository;

        protected BaseService(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public T GetById(int id)
        {
            return repository.GetById(id);
        }

        public T GetByName(string name)
        {
            return repository.GetByName(name);
        }

        public System.Collections.Generic.IEnumerable<T> GetAll()
        {
            return repository.GetAll();
        }

        public System.Collections.Generic.IEnumerable<T> GetMany(System.Func<T, bool> where)
        {
            return repository.GetMany(where);
        }

        public T Add(T t)
        {
            return repository.Add(t);
        }

        public T Update(T t)
        {
            return repository.Update(t);
        }

        public void Delete(T t)
        {
            repository.Delete(t);
        }
    }
}
