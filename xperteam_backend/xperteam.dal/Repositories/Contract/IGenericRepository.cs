using System.Linq.Expressions;

namespace xperteam.dal.Repositories.Contract
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        #region Methods Work Models
        Task<TModel> Get(Expression<Func<TModel, bool>> filter);

        Task<TModel> Create(TModel model);

        Task<bool> Update(TModel model);

        Task<bool> Delete(TModel model);

        Task<IQueryable<TModel>> Consult(Expression<Func<TModel,bool>> filter = null);
        #endregion
    }
}
