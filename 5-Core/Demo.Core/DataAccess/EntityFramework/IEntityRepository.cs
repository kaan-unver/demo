using System.Linq.Expressions;
using Demo.Core.Models;

namespace Demo.Core.DataAccess.EntityFramework
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter = null);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool SoftDelete(IEnumerable<T> entities);
        bool DeleteEntitySoftly(T entity);
        T Get(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes );
        List<T> GetAll(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        bool Delete(List<T> entities);
   



    }
}
