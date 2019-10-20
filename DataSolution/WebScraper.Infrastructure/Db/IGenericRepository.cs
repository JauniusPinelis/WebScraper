using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Infrastructure.Db
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Insert(T obj);

        void Save();
    }
}
