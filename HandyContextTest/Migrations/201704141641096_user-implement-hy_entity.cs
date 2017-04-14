namespace HandyContextTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userimplementhy_entity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.hy_user", "created_by_id", c => c.String(maxLength: 40));
            AddColumn("dbo.hy_user", "created_time", c => c.DateTime(nullable: false));
            AddColumn("dbo.hy_user", "last_modified_by_id", c => c.String(maxLength: 40));
            AddColumn("dbo.hy_user", "last_modified_time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.hy_user", "last_modified_time");
            DropColumn("dbo.hy_user", "last_modified_by_id");
            DropColumn("dbo.hy_user", "created_time");
            DropColumn("dbo.hy_user", "created_by_id");
        }
    }
}
