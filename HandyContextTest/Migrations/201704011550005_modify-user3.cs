namespace HandyContextTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyuser3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.hy_auth_rolehy_user", new[] { "hy_auth_role_Id" });
            AddColumn("dbo.hy_user", "name", c => c.String(maxLength: 50));
            CreateIndex("dbo.hy_auth_rolehy_user", "hy_auth_role_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.hy_auth_rolehy_user", new[] { "hy_auth_role_id" });
            DropColumn("dbo.hy_user", "name");
            CreateIndex("dbo.hy_auth_rolehy_user", "hy_auth_role_Id");
        }
    }
}
