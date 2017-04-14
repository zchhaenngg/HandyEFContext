namespace HandyContextTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class historyaddcontextid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.hy_data_history", "context_id", c => c.String(nullable: false, maxLength: 40));
        }
        
        public override void Down()
        {
            DropColumn("dbo.hy_data_history", "context_id");
        }
    }
}
