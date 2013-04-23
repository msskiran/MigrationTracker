
using System;
using System.Collections.Generic;

namespace NewMigrationTracker.DataAccess.Repositories
{
    public interface IRepository<T> : IDisposable
    {
        T GetById(int id);
        T GetByName(string name);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Func<T, bool> where);
        T Add(T t);
        T Update(T t);
        void Delete(T t);
        new void Dispose();
        void SaveToDB();
    }
}
