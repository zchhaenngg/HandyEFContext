namespace HandyContextTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modify_HistoryField : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.HistoryFields", "LastModifiedById");
            DropColumn("dbo.HistoryFields", "LastModifiedTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HistoryFields", "LastModifiedTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.HistoryFields", "LastModifiedById", c => c.String(maxLength: 40));
        }
    }
}
