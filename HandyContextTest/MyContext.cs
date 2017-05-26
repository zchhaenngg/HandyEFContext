namespace HandyContextTest
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using HandyModel.Entity;
    using Handy.EF.Context;
    using Handy.EF.Model.Entity;
    using Handy.EF.Model.History;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class MyContext : HistoryDbContext<HistoryTable, HistoryField, HistoryFieldValue, LogEvent>
    {
        public MyContext()
            : base("name=TestModel")
        {
        }
        public MyContext(string loginId, long sessionId, string logEventType)
            : base("name=TestModel", loginId, sessionId, logEventType)
        {
        }

        public virtual DbSet<hy_user> hy_user { get; set; }
        public virtual DbSet<hy_auth_role> hy_auth_role { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<hy_user>()
                .HasMany(t => t.hy_auth_roles)
                .WithMany(o => o.hy_users)
                .Map(m => 
                {
                    m.ToTable("hy_auth_role_hy_user");
                });
        }
    }
}
