namespace HandyContextTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HistoryFields", "Name", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HistoryFields", "Name");
        }
    }
}
