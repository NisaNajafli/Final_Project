using Application.Services.Abstracts;
using DataAccess.DataContext;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Conrets
{
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity
    {
        private readonly ManagementDb _context;
        public Repository(ManagementDb context)
        {
            _context = context;
        }
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(int id)
        {
            _context.Set<T>().Remove(GetById(id));
        }

        public IEnumerable<T> GetAll(string includes = null)
        {
            IQueryable<T> query=_context.Set<T>().AsQueryable();
            if(includes != null)
            {
                query=query.Include(includes);
            }
            return query;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(i=>i.Id==id);
        }

        public void Update(T entity, int id)
        {
            var model = _context.Set<T>().Find(id);
            model = entity;
            _context.Set<T>().Update(model);
        }
    }
}
