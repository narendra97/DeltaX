using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace imdb.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<T> GetAsync(int id);

        IQueryable<T> Query();

        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);

        //Task DeleteAsync(int id);       // old logic

        Task DeleteAsync(T entity);     //changed int id to T entity
    }
}