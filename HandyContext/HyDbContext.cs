namespace HandyContext
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Infrastructure;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Data.Entity.Core.Objects;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Data.Entity.Core;
    using HandyContext.Entity.Interfaces;
    using HandyContext.Entity;

    public class HyDbContext : BaseDbContext
    {
        private HistoryComponent _historyComponent;
        protected virtual HistoryComponent HistoryComponent => _historyComponent ?? (_historyComponent = new HistoryComponent(this));

        public string LoginId { get; set; }
        public HyDbContext(string nameOrConnectionString)
            :base(nameOrConnectionString)
        {
            ChangedEvent += Changed;
            ChangedEvent += AddDataHistory;
        }

        public virtual DbSet<hy_data_history> hy_data_history { get; set; }

        protected virtual void AddDataHistory()
        {
            if (ChangeTracker.HasChanges())
            {
                foreach (var entry in ChangeTracker.Entries())
                {
                    if (entry.Entity is hy_data_history)
                    {
                        continue;
                    }
                    if (entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    {
                        continue;
                    }
                    HistoryComponent.Write(entry);
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
                        if (entry.Entity is hy_ICreator)
                        {
                            var entity = entry.Entity as hy_ICreator;
                            entity.created_by_id = LoginId;
                            entity.created_time = DateTime.UtcNow;
                        }
                        if (entry.Entity is hy_IModifier)
                        {
                            var entity = entry.Entity as hy_IModifier;
                            entity.last_modified_by_id = LoginId;
                            entity.last_modified_time = DateTime.UtcNow;
                        }
                    }
                }
            }
        }
    }
}
