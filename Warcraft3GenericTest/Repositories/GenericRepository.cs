using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Warcraft3GenericTest.Data;
using Warcraft3GenericTest.Interfaces;

namespace Warcraft3GenericTest.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, ITestEntity
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

        public async Task<TEntity> GetEntityByNameAsync<TInclude>(string name)
            where TInclude : class, IIncludeName
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(e => (e as TInclude).Name == name);
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

        public async Task<TEntity> MapCreateDTOToEntityAsync<TDTOEntity, TEntity>(TDTOEntity createDTO)
           where TDTOEntity : class, IIncludeName
           where TEntity : class
            {
                var entity = Activator.CreateInstance<TEntity>(); // Create an instance of TEntity

                // Assume that TEntity has a property "Name" for the example
                var nameProperty = typeof(TEntity).GetProperty("Name");
                if (nameProperty != null)
                {
                    // Get the value of the "Name" property from the createDTO
                    var nameValue = createDTO.GetType().GetProperty("Name")?.GetValue(createDTO);

                    // Attempt to find an existing entity in the context with the specified name
                    var existingEntity = await _context.Set<TEntity>().FirstOrDefaultAsync(e => nameProperty.GetValue(e).ToString() == nameValue.ToString());

                    // Set the property to the existing entity or create a new instance if not found
                    nameProperty.SetValue(entity, existingEntity ?? Activator.CreateInstance<TEntity>());
                }

                // Add additional mapping logic based on your requirements

            return entity as TEntity;
        }


    }
}

