namespace HandyContextTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyuser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.hy_user", "locked_time");
            DropColumn("dbo.hy_user", "password_hash");
            DropColumn("dbo.hy_user", "security_stamp");
            DropColumn("dbo.hy_user", "phone_number");
            DropColumn("dbo.hy_user", "phone_number_confirmed");
            DropColumn("dbo.hy_user", "two_factor_enabled");
            DropColumn("dbo.hy_user", "email_confirmed");
            DropColumn("dbo.hy_user", "user_name");
            DropColumn("dbo.hy_user", "nick_name");
            DropColumn("dbo.hy_user", "email");
            DropColumn("dbo.hy_user", "is_valid");
            DropColumn("dbo.hy_user", "created_by_id");
            DropColumn("dbo.hy_user", "created_time");
            DropColumn("dbo.hy_user", "last_modified_by_id");
            DropColumn("dbo.hy_user", "last_modified_time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.hy_user", "last_modified_time", c => c.DateTime(nullable: false));
            AddColumn("dbo.hy_user", "last_modified_by_id", c => c.String(maxLength: 40));
            AddColumn("dbo.hy_user", "created_time", c => c.DateTime(nullable: false));
            AddColumn("dbo.hy_user", "created_by_id", c => c.String(maxLength: 40));
            AddColumn("dbo.hy_user", "is_valid", c => c.Boolean(nullable: false));
            AddColumn("dbo.hy_user", "email", c => c.String(maxLength: 256));
            AddColumn("dbo.hy_user", "nick_name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.hy_user", "user_name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.hy_user", "email_confirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.hy_user", "two_factor_enabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.hy_user", "phone_number_confirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.hy_user", "phone_number", c => c.String(maxLength: 250));
            AddColumn("dbo.hy_user", "security_stamp", c => c.String(nullable: false));
            AddColumn("dbo.hy_user", "password_hash", c => c.String(nullable: false));
            AddColumn("dbo.hy_user", "locked_time", c => c.DateTime());
        }
    }
}
