using Application.Services.Abstracts;
using DataAccess.DataContext;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Concrets
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
            var model = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(model);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> exp = null, params string[] includes)
        {
            IQueryable<T> query = _context.Set<T>().AsQueryable();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return exp is null
              ? await query.ToListAsync()
              : await query.Where(exp).ToListAsync();
        }

        public async Task<List<T>> GetAllAsyncIncludes(Expression<Func<T, bool>> exp = null, params string[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return exp is null
                ? await query.ToListAsync()
                : await query.Where(exp).ToListAsync();
        }

        public IQueryable<T> Get(params string[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return query;
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> exp = null, params string[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return exp is null
                ? await query.FirstOrDefaultAsync()
                : await query.Where(exp).FirstOrDefaultAsync();
        }


        public Task<T> GetById(int id)
        {
            return _context.Set<T>().FirstOrDefaultAsync(i => i.Id == id);
        }

        public void Update(T entity, int id)
        {
            var model = _context.Set<T>().Find(id);
            model = entity;
            _context.Set<T>().Update(model);
        }
      
    }
}
