using AutoMapper;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Urlize_back.Models;

namespace Urlize_back.Services
{

    public class GenericCRUDService<TModel,Tdto1,Tdto2> : IGenericCRUDService<TModel,Tdto1,Tdto2>
     where TModel : class
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;
        private AppDbContext context;
        private object value;

        public GenericCRUDService(IMapper mapper, AppDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

       

        public async Task<IEnumerable<TModel>> GetAll(Expression<Func<TModel, bool>>? where = null,
            params string[] includes)
        {
            var query = ApplyIncludes(_dbContext.Set<TModel>(), includes);

            if (where != null)
            {
                query = query.Where(where);
            }

            return await query.ToListAsync();
        }

        public async Task<TModel?> GetById(Expression<Func<TModel, bool>> predicateToGetId, params string[] includes)
        {
            var query = ApplyIncludes(_dbContext.Set<TModel>(), includes);

            var entity = await query.FirstOrDefaultAsync(predicateToGetId);

           
            if (entity == null)
            {
                
                throw new InvalidOperationException("Resource not found");
            }

            return entity;
        }

        public async Task<TModel> Add(Tdto1 dto)
        {
            if (dto == null) { throw new Exception("bad request"); }
            var entity = _mapper.Map<TModel>(dto);
            await _dbContext.Set<TModel>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TModel> Update(int id, Tdto2 dto)
        {
            var entity = await _dbContext.Set<TModel>().FindAsync(id);
            if (entity == null)
            {
                throw new InvalidOperationException("La ressource n'a pas été trouvée.");
            }

            _mapper.Map(dto, entity);

            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TModel>(entity);
            /*   var existingEntity = await _dbContext.Set<TModel>().FindAsync(id);

               if (existingEntity == null)
               {
                   throw new ArgumentException($"Entity with id {id} not found");
               }

               _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);

               await _dbContext.SaveChangesAsync();

               return existingEntity;*/
        }


        public async Task<TModel> Delete(int id)
        {
            var entity = await _dbContext.Set<TModel>().FindAsync(id);
            if (entity == null) { throw new ArgumentException($"Entity with id {id} not found"); }

            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        private IQueryable<TModel> ApplyIncludes(IQueryable<TModel> query, params string[] includes)
        {
            return includes.Aggregate(query, (current, include) => current.Include(include));
        }
    }

}
