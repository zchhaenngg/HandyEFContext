namespace HandyContextTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifytablename2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.hy_auth_roles_hy_users", newName: "hy_auth_role_hy_user");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.hy_auth_role_hy_user", newName: "hy_auth_roles_hy_users");
        }
    }
}
