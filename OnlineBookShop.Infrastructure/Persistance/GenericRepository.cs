using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Appilcation.Common.Interfaces;
using OnlineBookShop.Domain;

namespace OnlineBookShop.Infrastructure.Persistance
{
    public class GenericRepository : IRepository
    {
        private readonly OnlineBookShopDbContext _dbContext;

        public GenericRepository(OnlineBookShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync<T>(T entity) where T : BaseEntity
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public async Task<T> DeleteAsync<T>(int id) where T : BaseEntity
        {
            var item = await _dbContext.Set<T>().FindAsync(id);

            if (item == null)
            {
                throw new ArgumentNullException();
            }

            _dbContext.Set<T>().Remove(item);

            return item;
        }

        public async Task<List<T>> GetAllAsync<T>() where T : BaseEntity
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id) where T : BaseEntity
        {
            var item = await _dbContext.Set<T>().FindAsync(id);

            if (item == null)
            {
                throw new ArgumentNullException();
            }

            return item;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
