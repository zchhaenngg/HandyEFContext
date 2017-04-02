namespace HandyContextTest
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using HandyContext;

    public partial class MyContext : HyDbContext
    {
        public MyContext()
            : base("name=TestModel")
        {
        }

        public virtual DbSet<hy_user> hy_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
