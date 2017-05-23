namespace HandyContextTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.hy_user", "hy_auth_role_id", "dbo.hy_auth_role");
            DropForeignKey("dbo.hy_auth_role", "hy_user_Id", "dbo.hy_user");
            DropIndex("dbo.hy_user", new[] { "hy_auth_role_id" });
            DropIndex("dbo.hy_auth_role", new[] { "hy_user_Id" });
            CreateTable(
                "dbo.hy_auth_roles_hy_users",
                c => new
                    {
                        hy_user_Id = c.String(nullable: false, maxLength: 40),
                        hy_auth_role_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.hy_user_Id, t.hy_auth_role_id })
                .ForeignKey("dbo.hy_user", t => t.hy_user_Id, cascadeDelete: true)
                .ForeignKey("dbo.hy_auth_role", t => t.hy_auth_role_id, cascadeDelete: true)
                .Index(t => t.hy_user_Id)
                .Index(t => t.hy_auth_role_id);
            
            DropColumn("dbo.hy_user", "hy_auth_role_id");
            DropColumn("dbo.hy_auth_role", "hy_user_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.hy_auth_role", "hy_user_Id", c => c.String(maxLength: 40));
            AddColumn("dbo.hy_user", "hy_auth_role_id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.hy_auth_roles_hy_users", "hy_auth_role_id", "dbo.hy_auth_role");
            DropForeignKey("dbo.hy_auth_roles_hy_users", "hy_user_Id", "dbo.hy_user");
            DropIndex("dbo.hy_auth_roles_hy_users", new[] { "hy_auth_role_id" });
            DropIndex("dbo.hy_auth_roles_hy_users", new[] { "hy_user_Id" });
            DropTable("dbo.hy_auth_roles_hy_users");
            CreateIndex("dbo.hy_auth_role", "hy_user_Id");
            CreateIndex("dbo.hy_user", "hy_auth_role_id");
            AddForeignKey("dbo.hy_auth_role", "hy_user_Id", "dbo.hy_user", "Id");
            AddForeignKey("dbo.hy_user", "hy_auth_role_id", "dbo.hy_auth_role", "id");
        }
    }
}
