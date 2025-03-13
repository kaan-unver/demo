using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using Demo.Core.Models;
using Demo.Core.Utilities.Extensions;

namespace Demo.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
         where TEntity : class, IEntity, new()
         where TContext : DbContext, new()
    {
        public bool Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                return context.SaveChanges() > 0;
            }
        }
        public bool Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                return context.SaveChanges() > 0;
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().SingleOrDefault() : context.Set<TEntity>().Where(filter).SingleOrDefault();
            }
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }
        public bool Update(TEntity entity)
        {
            using (TContext context = new())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                return context.SaveChanges() > 0;
            }
        }
        public bool SoftDelete(IEnumerable<TEntity> entities)
        {
            using (TContext context = new())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    foreach (var entity in entities)
                    {
                        var property = entity.GetType().GetProperty("IsDeleted");
                        var propertyValue = (bool?)property?.GetValue(entity);
                        if (propertyValue.HasValue)
                            property?.SetValue(entity, true);

                        context.Entry(entity).Property("IsDeleted").IsModified = true;
                        context.Entry(entity).Property("UpdatedDate").IsModified = true;
                        context.Entry(entity).Property("UpdatedBy").IsModified = true;

                        context.SaveChanges();
                    }
                    dbContextTransaction.Commit();
                    return true;
                }
            }
            return false;
        }
        public bool Delete(List<TEntity> entities)
        {
            using (TContext context = new TContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    foreach (var entity in entities)
                    {
                        var deletedEntity = context.Entry(entity);
                        deletedEntity.State = EntityState.Deleted;
                        context.SaveChanges();
                    }
                    dbContextTransaction.Commit();
                    return true;
                }
            }
        }
        public bool DeleteEntitySoftly(TEntity entity)
        {
            using (TContext context = new())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {

                    var property = entity.GetType().GetProperty("IsDeleted");
                    var propertyValue = (bool?)property?.GetValue(entity);
                    if (propertyValue.HasValue)
                        property?.SetValue(entity, true);
                    property = entity.GetType().GetProperty("UpdatedDate");
                    if (propertyValue.HasValue)
                        property?.SetValue(entity, DateTime.UtcNow.GetDateTimeNow());

                    context.Entry(entity).Property("IsDeleted").IsModified = true;
                    context.Entry(entity).Property("UpdatedDate").IsModified = true;
                    context.Entry(entity).Property("UpdatedBy").IsModified = true;

                    context.SaveChanges();

                    dbContextTransaction.Commit();
                    return true;
                }
            }
            return false;
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            using (TContext context = new TContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();


                if (includes != null)
                {
                    foreach (var include in includes)
                    {
                        query = query.Include(include);
                    }
                }

                return filter == null ? query.SingleOrDefault() : query.Where(filter).SingleOrDefault();
            }
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            using (TContext context = new TContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();

                if (includes != null)
                {
                    foreach (var include in includes)
                    {
                        query = query.Include(include);
                    }
                }

                return filter == null
                         ? query.ToList()
                         : query.Where(filter).ToList();
            }
        }
 
    }
}



