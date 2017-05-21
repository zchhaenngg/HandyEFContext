//namespace Handy.EF.Context
//{
//    using System;
//    using System.ComponentModel.DataAnnotations;
//    using System.Data.Entity;
//    using System.Data.Entity.Infrastructure;
//    using System.Linq;
//    using HandyModel.Entity;

//    public class HistoryComponent<THistory> where THistory : hy_data_history, new()
//    {
//        public HistoryDbContext<THistory> Context { get; set; }
//        public HistoryComponent(HistoryDbContext<THistory> context) => Context = context;

//        protected virtual string GetPrimaryKey(DbEntityEntry entry)
//        {
//            var type = Context.GetObjectType(entry.Entity.GetType());
//            var keys = type.GetProperties().Where(p => p.GetCustomAttributes(false).Any(c => c is KeyAttribute)).ToArray();
//            if (keys == null || keys.Length == 0)
//            {
//                return GetCurrentValue(entry, "id") ?? throw new Exception(string.Format("table {0}!Please add annotation [Key] on the primary key field", type.Name));
//            }
//            else
//            {//.Select(kv => kv.Value.ToString()).Aggregate(string.Empty, (str, v) => str + v);
//                return keys.Select(p => p.Name).Aggregate(string.Empty, (str, v) => str + type.GetProperty(v).GetValue(entry.Entity));
//            }
//        }
//        protected virtual THistory GetHistory(DbEntityEntry entry, params string[] ignores)
//        {
//            var data = new THistory
//            {
//                id = Guid.NewGuid().ToString(),
//                context_id = Context.ContextId,
//                CreatedById = Context.LoginId,
//                CreatedTime = DateTime.UtcNow,
//                unique_key = GetPrimaryKey(entry),
//                entity_name = Context.GetObjectType(entry.Entity.GetType()).Name,
//                description = GetHistoryDescription(entry, ignores),
//                operation = GetOperation(entry.State)
//            };
//            return data;
//        }

//        protected virtual string GetOperation(EntityState state)
//        {
//            switch (state)
//            {
//                case EntityState.Added:
//                    return "Added";
//                case EntityState.Modified:
//                    return "Modified";
//                case EntityState.Deleted:
//                    return "Deleted";
//                default:
//                    return state.ToString();

//            }
//        }

//        protected virtual string GetHistoryDescription(DbEntityEntry entry, params string[] ignores)
//        {
//            switch (entry.State)
//            {
//                case EntityState.Added:
//                    return entry.CurrentValues.PropertyNames.Where(p => ignores != null && !ignores.Contains(p) || ignores == null).Where(p => IsToRecord(entry.CurrentValues[p], null))
//                        .Select(p => string.Format("{0}:{1}", GetPropertyDescription(entry.Entity.GetType(), p), GetCurrentValue(entry, p)))
//                        .Aggregate((current, item) => { return current += "<br/>" + item; });
//                case EntityState.Modified:
//                    return entry.CurrentValues.PropertyNames.Where(p => ignores != null && !ignores.Contains(p) || ignores == null).Where(p => IsToRecord(entry.CurrentValues[p], entry.OriginalValues[p]))
//                        .Select(p => string.Format("{0}:{1} -> {2}", GetPropertyDescription(entry.Entity.GetType(), p), GetOrginalValue(entry, p), GetCurrentValue(entry, p)))
//                        .Aggregate((current, item) => { return current += "<br/>" + item; });
//                case EntityState.Deleted:
//                    return "Deleted！";
//                default:
//                    return null;
//            }
//        }

//        /// <summary>
//        /// currentValue not equal orginalValue;the value type should not be byte[].
//        /// </summary>
//        /// <param name="currentValue"></param>
//        /// <param name="orginalValue"></param>
//        /// <returns></returns>

//        protected virtual bool IsToRecord(object currentValue, object orginalValue)
//        {
//            if (currentValue == null && orginalValue == null)
//            {
//                return false;
//            }
//            else if (currentValue?.GetType() == typeof(byte[]) || (orginalValue?.GetType() == typeof(byte[])))
//            {
//                return false;
//            }
//            return currentValue != orginalValue;
//        }

//        protected virtual string GetCurrentValue(DbEntityEntry entry, string propertyName)
//        {
//            return entry.CurrentValues[propertyName]?.ToString();
//        }
//        protected virtual string GetOrginalValue(DbEntityEntry entry, string propertyName)
//        {
//            return entry.OriginalValues[propertyName]?.ToString();
//        }
//        public virtual void Write(DbEntityEntry entry, params string[] ignores)
//        {
//            var history = GetHistory(entry, ignores);
//            if (!string.IsNullOrWhiteSpace(history.description))
//            {
//                Context.Add(history);
//            }
//        }
//        protected virtual string GetPropertyDescription(Type entity, string propertyName)
//        {
//            var propertyInfo = entity.GetProperty(propertyName);
//            var displayAttribute = propertyInfo.GetCustomAttributes(false).FirstOrDefault(c => c is DisplayAttribute) as DisplayAttribute;
//            return displayAttribute?.Description ?? propertyName;
//        }
//    }
//}
