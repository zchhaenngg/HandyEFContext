namespace HandyContext
{
    using HandyContext.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;

    public class HistoryComponent
    {
        public HyDbContext Context { get; set; }
        public HistoryComponent(HyDbContext context) => Context = context;

        protected virtual string GetPrimaryKey(DbEntityEntry entry)
        {
            var type = Context.GetObjectType(entry.Entity.GetType());
            var keys = type.GetProperties().Where(p => p.GetCustomAttributes(false).Any(c => c is KeyAttribute)).ToArray();
            if (keys == null || keys.Length == 0)
            {
                return GetCurrentValue(entry, "id") ?? throw new Exception(string.Format("请对 {0} 的主键字段上增加注解[Key]", type.Name));
            }
            else
            {//.Select(kv => kv.Value.ToString()).Aggregate(string.Empty, (str, v) => str + v);
                return keys.Select(p=>p.Name).Aggregate(string.Empty, (str, v) => str + type.GetProperty(v).GetValue(entry.Entity));
            }
        }
        protected virtual hy_data_history GetHistory(DbEntityEntry entry, params string[] ignores)
        {
            var data = new hy_data_history
            {
                id = Guid.NewGuid().ToString(),
                created_by_id = Context.LoginId,
                created_time = DateTime.UtcNow,
                unique_key = GetPrimaryKey(entry),
                entity_name = Context.GetObjectType(entry.Entity.GetType()).Name,
                description = GetHistoryDescription(entry, ignores),
                operation = GetOperation(entry.State)
            };
            return data;
        }

        protected virtual string GetOperation(EntityState state)
        {
            switch (state)
            {
                case EntityState.Added:
                    return "新增";
                case EntityState.Modified:
                    return "修改";
                case EntityState.Deleted:
                default:
                    return "删除";
            }
        }

        protected virtual string GetHistoryDescription(DbEntityEntry entry, params string[] ignores)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    return entry.CurrentValues.PropertyNames.Where(p => !ignores?.Contains(p) != null && IsToRecord(entry.CurrentValues[p], null))
                        .Select(p => string.Format("{0}:{1}", Context.GetPropertyDescription(entry.Entity.GetType(), p), GetCurrentValue(entry, p)))
                        .Aggregate((current, item) => { return current += item + "<br/>"; });
                case EntityState.Modified:
                    return entry.CurrentValues.PropertyNames.Where(p => !ignores?.Contains(p) != null && IsToRecord(entry.CurrentValues[p], entry.OriginalValues[p]))
                        .Select(p => string.Format("{0}:{1} -> {2}", Context.GetPropertyDescription(entry.Entity.GetType(), p), GetOrginalValue(entry, p), GetCurrentValue(entry, p)))
                        .Aggregate((current, item) => { return current += item + "<br/>"; });
                case EntityState.Deleted:
                    return "已删除！";
                default:
                    return null;
            }
        }

        /// <summary>
        /// currentValue not equal orginalValue;the value type should not be byte[].
        /// </summary>
        /// <param name="currentValue"></param>
        /// <param name="orginalValue"></param>
        /// <returns></returns>

        protected virtual bool IsToRecord(object currentValue, object orginalValue)
        {
            if (currentValue == null && orginalValue == null)
            {
                return false;
            }
            else if (currentValue?.GetType() == typeof(byte[]) || (orginalValue?.GetType() == typeof(byte[])))
            {
                return false;
            }
            return currentValue != orginalValue;
        }

        protected virtual string GetCurrentValue(DbEntityEntry entry, string propertyName)
        {
            return entry.CurrentValues[propertyName]?.ToString();
        }
        protected virtual string GetOrginalValue(DbEntityEntry entry, string propertyName)
        {
            return entry.OriginalValues[propertyName]?.ToString();
        }
        public virtual void Write(DbEntityEntry entry, params string[] ignores)
        {  
            var history = GetHistory(entry, ignores);
            if (!string.IsNullOrWhiteSpace(history.description))
            {
                Context.Add(history);
            }
        }
    }
}
