namespace HandyContextTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyuser2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.hy_auth_role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.hy_auth_rolehy_user",
                c => new
                    {
                        hy_auth_role_Id = c.String(nullable: false, maxLength: 128),
                        hy_user_id = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => new { t.hy_auth_role_Id, t.hy_user_id })
                .ForeignKey("dbo.hy_auth_role", t => t.hy_auth_role_Id, cascadeDelete: true)
                .ForeignKey("dbo.hy_user", t => t.hy_user_id, cascadeDelete: true)
                .Index(t => t.hy_auth_role_Id)
                .Index(t => t.hy_user_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.hy_auth_rolehy_user", "hy_user_id", "dbo.hy_user");
            DropForeignKey("dbo.hy_auth_rolehy_user", "hy_auth_role_Id", "dbo.hy_auth_role");
            DropIndex("dbo.hy_auth_rolehy_user", new[] { "hy_user_id" });
            DropIndex("dbo.hy_auth_rolehy_user", new[] { "hy_auth_role_Id" });
            DropTable("dbo.hy_auth_rolehy_user");
            DropTable("dbo.hy_auth_role");
        }
    }
}
