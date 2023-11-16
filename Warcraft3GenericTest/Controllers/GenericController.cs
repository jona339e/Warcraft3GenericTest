using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Warcraft3GenericTest.DTO;
using Warcraft3GenericTest.Interfaces;
using Warcraft3GenericTest.Models;

namespace Warcraft3GenericTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T, TDTOEntity> : ControllerBase
        where T : class, ITestEntity
        where TDTOEntity : class, IIncludeName
    {
        private IGenericRepository<T> _repository;

        public GenericController(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<T>>> GetAllEntities()
        {
            try
            {
                var entities = await _repository.GetAllAsync(GetIncludes());
                return Ok(entities);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetById/{id}")]
        public virtual async Task<ActionResult<IEnumerable<T>>> GetById(int id)
        {
            try
            {
                var entities = await _repository.GetByIdAsync(id, GetIncludes());
                return Ok(entities);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, "Internal server error");
            }
        }

        // public virtual async Task<ActionResult<T>> Create([FromBody] T entity)
        [HttpPost]
        public virtual async Task<ActionResult<T>> Create([FromBody] DTOEntity<TDTOEntity> DTOEntity)
        {
            try
            {
                var entity = await _repository.MapCreateDTOToEntityAsync<TDTOEntity, T>(DTOEntity.Entity);
                var addedEntity = await _repository.AddAsync(entity);
                return CreatedAtAction(nameof(GetById), new { id = addedEntity.Id }, addedEntity);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpDelete("Delete/{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, "Internal server error");
            }
        }

        // Method to be overridden by derived controllers to specify includes
        protected virtual Func<IQueryable<T>, IIncludableQueryable<T, object>>[] GetIncludes()
        {
            // Default: no includes
            return Array.Empty<Func<IQueryable<T>, IIncludableQueryable<T, object>>>();
        }

        protected virtual int GetEntityId(T entity)
        {
            if (entity is ITestEntity entityWithId)
            {
                return entityWithId.Id;
            }

            // Handle the case where the entity doesn't implement IEntity
            throw new InvalidOperationException("Entity does not implement IEntity interface.");
        }


        // Method for manual mapping from DTO to Entity
        protected virtual T MapCreateDTOToEntity(TDTOEntity createDTO)
        {
            // Implement the mapping logic based on your requirements
            // Example: Property by property mapping
            // var entity = new T { Property1 = createDTO.Property1, Property2 = createDTO.Property2, ... };

            // Replace the above line with your specific mapping logic
            throw new NotImplementedException("Mapping from DTO to Entity not implemented.");
        }




    }
}
