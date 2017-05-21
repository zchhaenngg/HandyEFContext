//namespace Handy.EF.Context
//{
//    using System;
//    using System.Data.Entity;
//    using HandyModel.Entity;
//    using HandyModel.Entity.Interfaces;

//    public class HistoryDbContext<THistory> : GenericDbContext
//        where THistory : hy_data_history, new()
//    {
//        private HistoryComponent<THistory> _historyComponent;
//        protected virtual HistoryComponent<THistory> HistoryComponent => _historyComponent ?? (_historyComponent = new HistoryComponent<THistory>(this));

//        public string LoginId { get; set; }
//        public string ContextId { get; } = Guid.NewGuid().ToString();
//        public HistoryDbContext(string nameOrConnectionString)
//            : base(nameOrConnectionString)
//        {
//            ChangedEvent += Changed;
//            ChangedEvent += AddDataHistory;
//        }

//        public virtual DbSet<THistory> hy_data_history { get; set; }

//        protected virtual void AddDataHistory()
//        {
//            if (ChangeTracker.HasChanges())
//            {
//                foreach (var entry in ChangeTracker.Entries())
//                {
//                    if (entry.Entity is hy_data_history)
//                    {
//                        continue;
//                    }
//                    if (entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
//                    {
//                        continue;
//                    }
//                    HistoryComponent.Write(entry,
//                        nameof(ICreatorModifier.id),
//                        nameof(ICreatorModifier.CreatedById),
//                        nameof(ICreatorModifier.CreatedTime),
//                        nameof(ICreatorModifier.Last_modified_by_id),
//                        nameof(ICreatorModifier.Last_modified_time));
//                }
//            }
//        }

//        protected virtual void Changed()
//        {
//            if (ChangeTracker.HasChanges())
//            {
//                foreach (var entry in ChangeTracker.Entries())
//                {
//                    if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
//                    {
//                        if (entry.Entity is ICreator)
//                        {
//                            var entity = entry.Entity as ICreator;
//                            entity.CreatedById = LoginId;
//                            entity.CreatedTime = DateTime.UtcNow;
//                        }
//                        if (entry.Entity is IHy_IModifier)
//                        {
//                            var entity = entry.Entity as IHy_IModifier;
//                            entity.Last_modified_by_id = LoginId;
//                            entity.Last_modified_time = DateTime.UtcNow;
//                        }
//                    }
//                }
//            }
//        }
//    }
//}
