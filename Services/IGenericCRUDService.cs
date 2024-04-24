using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Urlize_back.Services
{
    public interface IGenericCRUDService<TModel,Tdto>
    {
        Task<IEnumerable<TModel>> GetAll(Expression<Func<TModel, bool>>? where = null, params string[] includes);
        Task<TModel?> GetById(Expression<Func<TModel, bool>> predicateToGetId, params string[] includes);
        Task<TModel> Add(Tdto entity);
        Task<TModel> Update(int id, Tdto entity);
        Task<TModel> Delete(int id);
    }
}
