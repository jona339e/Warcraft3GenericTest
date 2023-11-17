using Microsoft.EntityFrameworkCore.Query;

namespace Warcraft3GenericTest.Interfaces
{
    public interface IGenericRepository<TEntity> 
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync(params Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>[] includes);
        Task<TEntity> GetByIdAsync(int id, params Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>[] includes);
        Task<TEntity> GetByNameAsync<TDTOEntity>(TDTOEntity DTO, params Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>[] includes);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
}
