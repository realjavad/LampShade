using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Features.Domain
{
    public interface IRepository<in TKey, T> where T : class
    {
        void Create(T entity);
        List<T> GetAll();
        T Get(TKey id);
        bool Exists(Expression<Func<T, bool>> expression);
        void Save();
    }
}
