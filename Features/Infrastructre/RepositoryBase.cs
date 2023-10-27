using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Features.Domain;
using Microsoft.EntityFrameworkCore;

namespace Features.Infrastructre
{
    public class RepositoryBase<TKey, T> : IRepository<TKey, T> where T : class
    {
        private readonly DbContext _context;
        public RepositoryBase(DbContext context)
        {
            _context = context;
        }
        public void Create(T entity)
        {
            _context.Add<T>(entity);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public T Get(TKey id)
        {
            return _context.Find<T>(id);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
