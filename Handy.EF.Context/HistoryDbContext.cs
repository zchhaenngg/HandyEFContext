namespace Handy.EF.Context
{
    using System;
    using System.Data.Entity;
    using Handy.EF.Context.History;
    using Handy.EF.Context.History.Interfaces;
    using Handy.EF.Model.Entity;
    using HandyModel.Entity;
    using HandyModel.Entity.Interfaces;

    public class HistoryDbContext<THistoryTable, THistoryField, THistoryFieldValue, TLogEvent> : GenericDbContext
        where THistoryTable : HistoryTable, new()
        where THistoryField : HistoryField, new()
        where THistoryFieldValue : HistoryFieldValue, new()
        where TLogEvent: LogEvent
    {
        private HistoryComponent<THistoryTable, THistoryField, THistoryFieldValue, TLogEvent> _historyComponent;
        protected virtual HistoryComponent<THistoryTable, THistoryField, THistoryFieldValue, TLogEvent> HistoryComponent => _historyComponent ?? (_historyComponent = new HistoryComponent<THistoryTable, THistoryField, THistoryFieldValue, TLogEvent>(this));

        public string LoginId { get; set; }
        public TLogEvent LogEvent { get; set; }
        public HistoryDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            ChangedEvent += Changed;
            ChangedEvent += AddDataHistory;
        }

        public virtual DbSet<THistoryTable> HistoryTable { get; set; }
        public virtual DbSet<THistoryField> HistoryField { get; set; }
        public virtual DbSet<THistoryFieldValue> HistoryFieldValue { get; set; }
        public virtual DbSet<TLogEvent> LogEventSet { get; set; }

        protected virtual void AddDataHistory()
        {
            if (ChangeTracker.HasChanges())
            {
                foreach (var entry in ChangeTracker.Entries())
                {
                    if (entry.Entity is INotRecordHistory)
                    {
                        continue;
                    }
                    if (entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    {
                        continue;
                    }
                    LogEventSet.Add(LogEvent);
                    HistoryComponent.Write(entry,
                        nameof(IKey.Id),
                        nameof(ICreator.CreatedById),
                        nameof(ICreator.CreatedTime),
                        nameof(IModifier.LastModifiedById),
                        nameof(IModifier.LastModifiedTime));
                }
            }
        }

        protected virtual void Changed()
        {
            if (ChangeTracker.HasChanges())
            {
                foreach (var entry in ChangeTracker.Entries())
                {
                    if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                    {
                        if (entry.Entity is ICreator)
                        {
                            var entity = entry.Entity as ICreator;
                            entity.CreatedById = LoginId;
                            entity.CreatedTime = DateTime.UtcNow;
                        }
                        if (entry.Entity is IModifier)
                        {
                            var entity = entry.Entity as IModifier;
                            entity.LastModifiedById = LoginId;
                            entity.LastModifiedTime = DateTime.UtcNow;
                        }
                    }
                }
            }
        }
    }
}
