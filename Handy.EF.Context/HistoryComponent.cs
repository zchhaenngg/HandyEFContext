namespace Handy.EF.Context
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using Handy.EF.Model.Entity;
    using Handy.EF.Model.History;
    using HandyModel.Entity;
    using HandyModel.Entity.Interfaces;

    public class HistoryComponent<THistoryTable, THistoryField, THistoryFieldValue, TLogEvent> 
        where THistoryTable : HistoryTable, new()
        where THistoryField : HistoryField, new()
        where THistoryFieldValue : HistoryFieldValue, new()
        where TLogEvent : LogEvent
    {
        public HistoryDbContext<THistoryTable, THistoryField, THistoryFieldValue, TLogEvent> Context { get; set; }
        public HistoryComponent(HistoryDbContext<THistoryTable, THistoryField, THistoryFieldValue, TLogEvent> context) => Context = context;

        protected virtual string GetPrimaryKey(DbEntityEntry entry) => (entry.Entity as IKey)?.Id;
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
            if (entry.State == EntityState.Deleted)
            {
                var id = GetPrimaryKey(entry);
                Context.HistoryField.Remove(Context.HistoryField.First(o => o.UniqueKey == id));
            }
            else
            {
                THistoryTable table = AddTable(entry);
                var propertyNames = entry.CurrentValues.PropertyNames.Where(p => ignores != null && !ignores.Contains(p) || ignores == null);
                switch (entry.State)
                {
                    case EntityState.Added:
                        propertyNames = propertyNames.Where(p => IsToRecord(entry.CurrentValues[p], null));
                        break;
                    case EntityState.Modified:
                        propertyNames = propertyNames.Where(p => IsToRecord(entry.CurrentValues[p], entry.OriginalValues[p]));
                        break;
                    case EntityState.Detached:
                    case EntityState.Unchanged:
                    default:
                        throw new Exception("unreached code");
                }
                foreach (var prop in propertyNames)
                {
                    WriteFieldChanged(entry, table, prop);
                }
            }
        }
        protected string GetTableName(DbEntityEntry entry)
        {
            var entityType = Context.GetObjectType(entry.Entity.GetType());
            var attr = entityType.GetCustomAttributes(false).FirstOrDefault(c => c is TableAttribute) as TableAttribute;
            return attr != null ? attr.Name : entityType.Name;
        }
        private THistoryTable AddTable(DbEntityEntry entry)
        {
            var tableName = GetTableName(entry);
            var table = Context.HistoryTable.FirstOrDefault(o => o.Name == tableName);
            if (table == null)
            {
                table = new THistoryTable
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = tableName,
                    CreatedById = Context.LoginId,
                    CreatedTime = DateTime.UtcNow
                };
                Context.HistoryTable.Add(table);
            }

            return table;
        }

        private void WriteFieldChanged(DbEntityEntry entry, THistoryTable table, string prop)
        {
            var columnName = GetColumnName(entry.Entity.GetType(), prop);
            var key = GetPrimaryKey(entry);
            var field = Context.HistoryField.FirstOrDefault(o => o.UniqueKey == key);
            if (field == null)
            {
                field = new THistoryField
                {
                    Id = Guid.NewGuid().ToString(),
                    UniqueKey = key,
                    Table = table,
                    Name = columnName,
                    CreatedById = Context.LoginId,
                    CreatedTime = DateTime.UtcNow,
                    LastModifiedById = Context.LoginId,
                    LastModifiedTime = DateTime.UtcNow
                };
            }
            field.Values.Add(new HistoryFieldValue
            {
                Id = Guid.NewGuid().ToString(),
                Value = entry.CurrentValues[prop]?.ToString(),
                CreatedById = Context.LoginId,
                CreatedTime = DateTime.UtcNow
            });
            Context.HistoryField.Add(field);
        }

        protected string GetColumnName(Type entityType, string propertyName)
        {
            var attr = entityType.GetProperty(propertyName).GetCustomAttributes(false).FirstOrDefault(o => o is ColumnAttribute) as ColumnAttribute;
            return attr != null ? attr.Name : propertyName;
        }
    }
}
