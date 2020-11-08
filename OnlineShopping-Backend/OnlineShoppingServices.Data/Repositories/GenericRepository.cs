using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using OnlineShoppingServices.Common.Interfaces;
using OnlineShoppingServices.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingServices.Data
{
    // generic repository ,which consists of async operations
    public class GenericRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly ShoppingDBContext context;

        public GenericRepository(ShoppingDBContext apiContext)
        {
            context = apiContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity).ConfigureAwait(false);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return entity;
                    }

        public async Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IList<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().Where(expression).ToListAsync().ConfigureAwait(false);
        }

        public async Task<T> SingleOrDefaultAsync
       (Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().SingleOrDefaultAsync(expression).ConfigureAwait(false);
        }
        public async Task<T> GetAsync(int id)
        {
            return await context.Set<T>().FindAsync(id).ConfigureAwait(false);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync().ConfigureAwait(false);
            return entity;
        }

    }
}
