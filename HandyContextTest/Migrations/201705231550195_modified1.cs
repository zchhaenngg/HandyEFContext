namespace HandyContextTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modified1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.hy_auth_role", "Creator_Id", "dbo.hy_user");
            DropForeignKey("dbo.hy_auth_roles_hy_users", "hy_auth_role_id", "dbo.hy_auth_role");
            DropIndex("dbo.hy_auth_role", new[] { "Creator_Id" });
            DropIndex("dbo.hy_auth_roles_hy_users", new[] { "hy_auth_role_id" });
            DropPrimaryKey("dbo.hy_auth_role");
            DropPrimaryKey("dbo.hy_auth_roles_hy_users");
            AddColumn("dbo.hy_auth_role", "CreatedById", c => c.String(maxLength: 40));
            AddColumn("dbo.hy_auth_role", "CreatedTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.hy_auth_role", "LastModifiedById", c => c.String(maxLength: 40));
            AddColumn("dbo.hy_auth_role", "LastModifiedTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.hy_auth_role", "Id", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.hy_auth_roles_hy_users", "hy_auth_role_Id", c => c.String(nullable: false, maxLength: 40));
            AddPrimaryKey("dbo.hy_auth_role", "Id");
            AddPrimaryKey("dbo.hy_auth_roles_hy_users", new[] { "hy_user_Id", "hy_auth_role_Id" });
            CreateIndex("dbo.hy_auth_roles_hy_users", "hy_auth_role_Id");
            AddForeignKey("dbo.hy_auth_roles_hy_users", "hy_auth_role_Id", "dbo.hy_auth_role", "Id", cascadeDelete: true);
            DropColumn("dbo.hy_auth_role", "Creator_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.hy_auth_role", "Creator_Id", c => c.String(maxLength: 40));
            DropForeignKey("dbo.hy_auth_roles_hy_users", "hy_auth_role_Id", "dbo.hy_auth_role");
            DropIndex("dbo.hy_auth_roles_hy_users", new[] { "hy_auth_role_Id" });
            DropPrimaryKey("dbo.hy_auth_roles_hy_users");
            DropPrimaryKey("dbo.hy_auth_role");
            AlterColumn("dbo.hy_auth_roles_hy_users", "hy_auth_role_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.hy_auth_role", "Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.hy_auth_role", "LastModifiedTime");
            DropColumn("dbo.hy_auth_role", "LastModifiedById");
            DropColumn("dbo.hy_auth_role", "CreatedTime");
            DropColumn("dbo.hy_auth_role", "CreatedById");
            AddPrimaryKey("dbo.hy_auth_roles_hy_users", new[] { "hy_user_Id", "hy_auth_role_id" });
            AddPrimaryKey("dbo.hy_auth_role", "id");
            CreateIndex("dbo.hy_auth_roles_hy_users", "hy_auth_role_id");
            CreateIndex("dbo.hy_auth_role", "Creator_Id");
            AddForeignKey("dbo.hy_auth_roles_hy_users", "hy_auth_role_id", "dbo.hy_auth_role", "id", cascadeDelete: true);
            AddForeignKey("dbo.hy_auth_role", "Creator_Id", "dbo.hy_user", "Id");
        }
    }
}
