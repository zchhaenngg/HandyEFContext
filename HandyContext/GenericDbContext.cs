namespace HandyContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GenericDbContext : DbContext
    {
        public GenericDbContext(string nameOrConnectionString)
            :base(nameOrConnectionString)
        {
        }
        public event Action ChangedEvent;
        
        public override int SaveChanges()
        {
            ChangedEvent?.Invoke();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync()
        {
            ChangedEvent?.Invoke();
            return base.SaveChangesAsync();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            ChangedEvent?.Invoke();
            return base.SaveChangesAsync(cancellationToken);
        }

        public TEntity Add<TEntity>(TEntity entity) where TEntity : class
        {
            return Set<TEntity>().Add(entity);
        }
        public IEnumerable<TEntity> AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            return Set<TEntity>().AddRange(entities);
        }
        /// <summary>
        /// 从上下文中移除表TEntity中的所有指定记录
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entities"></param>
        public void RemoveAndClear<TEntity>(ICollection<TEntity> entities) where TEntity : class
        {
            Set<TEntity>().RemoveRange(entities);
            entities.Clear();
        }
        public TEntity Remove<TEntity>(TEntity entity) where TEntity : class
        {
            return Set<TEntity>().Remove(entity);
        }
        /// <summary>
        ///  Returns the entity type of the POCO entity associated with a proxy object of a specified type.
        /// </summary>
        /// <param name="entityType">The System.Type of the proxy object.</param>
        /// <returns>The System.Type of the associated POCO entity.</returns>
        public Type GetObjectType(Type entityType)
        {
            return ObjectContext.GetObjectType(entityType);
        }
        public DbQuery<TEntity> AsNoTracking<TEntity>() where TEntity : class
        {
            return Set<TEntity>().AsNoTracking();
        }
        public DbSet<TEntity> AsTracking<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }
    }
}
