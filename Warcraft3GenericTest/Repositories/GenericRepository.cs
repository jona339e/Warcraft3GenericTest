using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Warcraft3GenericTest.Data;
using Warcraft3GenericTest.DTO;
using Warcraft3GenericTest.Interfaces;

namespace Warcraft3GenericTest.Repositories
{
    public class GenericRepository<TEntity, TDTOEntity> : IGenericRepository<TEntity>
        where TEntity : class, ITestEntity
        where TDTOEntity : class , IIncludeName

    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<TEntity>> GetAllAsync(params Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().OrderBy(x => x.Id);

            foreach (var include in includes)
            {
                query = include(query);
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id, params Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>[] includes)
        {
            var query = (DbSet<TEntity>)_context.Set<TEntity>();

            foreach (var include in includes)
            {
                query = (DbSet<TEntity>)include(query);
            }

            return await query.FindAsync(id);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var addedEntity = _context.Set<TEntity>().Add(entity).Entity;
            await _context.SaveChangesAsync();
            return addedEntity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> GetByNameAsync<TDTOEntity>(TDTOEntity DTO, params Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>[] includes)
        {
            // Ensure the DTO implements IIncludeName
            if (!(DTO is IIncludeName includeNameDTO))
            {
                throw new ArgumentException("DTO must implement IIncludeName", nameof(DTO));
            }

            var query = _context.Set<TEntity>().AsQueryable();

            // Apply includes if provided
            foreach (var include in includes)
            {
                query = include(query);
            }

            // Fetch all entities and filter by name
            var entities = await query.ToListAsync();
            var entity = entities.OfType<IIncludeName>().FirstOrDefault(e => e.Name == includeNameDTO.Name) as TEntity;

            if (entity == null)
            {
                throw new ArgumentException($"Entity with name '{includeNameDTO.Name}' not found");
            }

            return entity;
        }

    }
}

