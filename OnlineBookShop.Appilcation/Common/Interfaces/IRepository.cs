using OnlineBookShop.Domain;

namespace OnlineBookShop.Appilcation.Common.Interfaces
{
    public interface IRepository
    {
        Task<T> GetByIdAsync<T>(int id) where T : BaseEntity;

        Task<List<T>> GetAllAsync<T>() where T : BaseEntity;

        Task AddAsync<T>(T entity) where T : BaseEntity;

        Task<T> DeleteAsync<T>(int id) where T : BaseEntity;

        Task UpdateAsync<T>(T entity) where T : BaseEntity;

        Task SaveChangesAsync();
    }
}
