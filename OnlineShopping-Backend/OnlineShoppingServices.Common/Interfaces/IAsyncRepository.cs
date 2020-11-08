using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingServices.Common.Interfaces
{
    // interface,which consists of async operations
    public interface IAsyncRepository<T> where T : class
    {

        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IList<T>> FindAsync(Expression<Func<T, bool>> expression);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression);

    }
}

