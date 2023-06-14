using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstracts
{
    public interface IRepository<T> where T :class,IBaseEntity
    {
        Task<T> GetById (int id);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> exp = null,params string[] includes);
        IQueryable<T> Get(params string[] includes);
        Task<T> GetAsync(Expression<Func<T, bool>> exp = null, params string[] includes);
        Task<List<T>> GetAllAsyncIncludes(Expression<Func<T, bool>> exp = null, params string[] includes);
        void Create(T entity);
        void Update(T entity,int id);
        void Delete(int id);

    }
}
