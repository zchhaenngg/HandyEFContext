namespace HandyContextTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rolecreator : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.hy_auth_rolehy_user", "hy_auth_role_id", "dbo.hy_auth_role");
            DropForeignKey("dbo.hy_auth_rolehy_user", "hy_user_id", "dbo.hy_user");
            DropIndex("dbo.hy_auth_rolehy_user", new[] { "hy_auth_role_id" });
            DropIndex("dbo.hy_auth_rolehy_user", new[] { "hy_user_id" });
            AddColumn("dbo.hy_user", "hy_auth_role_id", c => c.String(maxLength: 128));
            AddColumn("dbo.hy_auth_role", "Creator_id", c => c.String(maxLength: 40));
            AddColumn("dbo.hy_auth_role", "hy_user_id", c => c.String(maxLength: 40));
            CreateIndex("dbo.hy_user", "hy_auth_role_id");
            CreateIndex("dbo.hy_auth_role", "Creator_id");
            CreateIndex("dbo.hy_auth_role", "hy_user_id");
            AddForeignKey("dbo.hy_auth_role", "Creator_id", "dbo.hy_user", "id");
            AddForeignKey("dbo.hy_user", "hy_auth_role_id", "dbo.hy_auth_role", "id");
            AddForeignKey("dbo.hy_auth_role", "hy_user_id", "dbo.hy_user", "id");
            DropTable("dbo.hy_auth_rolehy_user");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.hy_auth_rolehy_user",
                c => new
                    {
                        hy_auth_role_id = c.String(nullable: false, maxLength: 128),
                        hy_user_id = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => new { t.hy_auth_role_id, t.hy_user_id });
            
            DropForeignKey("dbo.hy_auth_role", "hy_user_id", "dbo.hy_user");
            DropForeignKey("dbo.hy_user", "hy_auth_role_id", "dbo.hy_auth_role");
            DropForeignKey("dbo.hy_auth_role", "Creator_id", "dbo.hy_user");
            DropIndex("dbo.hy_auth_role", new[] { "hy_user_id" });
            DropIndex("dbo.hy_auth_role", new[] { "Creator_id" });
            DropIndex("dbo.hy_user", new[] { "hy_auth_role_id" });
            DropColumn("dbo.hy_auth_role", "hy_user_id");
            DropColumn("dbo.hy_auth_role", "Creator_id");
            DropColumn("dbo.hy_user", "hy_auth_role_id");
            CreateIndex("dbo.hy_auth_rolehy_user", "hy_user_id");
            CreateIndex("dbo.hy_auth_rolehy_user", "hy_auth_role_id");
            AddForeignKey("dbo.hy_auth_rolehy_user", "hy_user_id", "dbo.hy_user", "id", cascadeDelete: true);
            AddForeignKey("dbo.hy_auth_rolehy_user", "hy_auth_role_id", "dbo.hy_auth_role", "id", cascadeDelete: true);
        }
    }
}
