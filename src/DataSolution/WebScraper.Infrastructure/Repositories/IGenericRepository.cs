using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Infrastructure.Repositories
{
    public interface  IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Upsert(T obj, object id);
        void Delete(object id);
        void Save();
    }
}
