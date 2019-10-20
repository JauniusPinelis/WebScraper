using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebScraper.Infrastructure.Db
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private JobDbContext _context = null;
        private DbSet<T> table = null;

        public GenericRepository()
        {
            _context = new JobDbContext();
            table = _context.Set<T>();
        }

        public GenericRepository(JobDbContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public void Insert(T obj)
        {
            _context.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
