using System;
using System.Linq;
using System.Threading.Tasks;
using imdb.Domain;
using Microsoft.EntityFrameworkCore;

namespace imdb.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity, new()
    {
        protected IMDBDbContext _dbContext { get; set; }

        public async Task<T> GetAsync(int id)
        {
            return await _dbContext.FindAsync<T>(id);
        }

        public IQueryable<T> Query()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public async Task InsertAsync(T entity)
        {
            entity.Created_At = DateTime.UtcNow;
            entity.Updated_At = DateTime.UtcNow;

            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            entity.Updated_At = DateTime.UtcNow;

            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        //old DeleteAsync() method
        //public async Task DeleteAsync(int id)
        //{
        //    T entity = new T() { Id = id };
        //    await DeleteAsync(entity);
        //}


        //
        public async Task DeleteAsync(T entity)      //use entity as an article object we have to delete entire object not only id
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }
    }
}