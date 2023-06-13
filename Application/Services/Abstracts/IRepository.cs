using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstracts
{
    public interface IRepository<T> where T :class,IBaseEntity
    {
        T GetById (int id);
        IEnumerable<T> GetAll(string includes=null);
        void Create(T entity);
        void Update(T entity,int id);
        void Delete(int id);

    }
}
