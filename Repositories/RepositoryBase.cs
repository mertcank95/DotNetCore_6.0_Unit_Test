using Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class,IEntity
    {

        protected readonly RepositoryContext _context;

        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            //_context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);

        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
           return _context.Set<T>().Where(expression).AsNoTracking();
            
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

       
    }
}
