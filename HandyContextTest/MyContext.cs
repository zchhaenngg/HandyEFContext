//namespace HandyContextTest
//{
//    using System;
//    using System.Data.Entity;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Linq;
//    using HandyContext;
//    using HandyModel.Entity;

//    public partial class MyContext : HistoryDbContext<hy_data_history>
//    {
//        public MyContext()
//            : base("name=TestModel")
//        {
//        }

//        public virtual DbSet<hy_user> hy_user { get; set; }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//        }
//    }
//}
