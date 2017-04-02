namespace HandyContextTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.hy_data_history",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 40),
                        entity_name = c.String(maxLength: 50),
                        unique_key = c.String(nullable: false, maxLength: 40),
                        operation = c.String(maxLength: 50),
                        description = c.String(nullable: false),
                        created_by_id = c.String(maxLength: 40),
                        created_time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.hy_user",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 40),
                        access_failed_times = c.Int(nullable: false),
                        is_locked = c.Boolean(nullable: false),
                        locked_time = c.DateTime(),
                        password_hash = c.String(nullable: false),
                        security_stamp = c.String(nullable: false),
                        phone_number = c.String(maxLength: 250),
                        phone_number_confirmed = c.Boolean(nullable: false),
                        two_factor_enabled = c.Boolean(nullable: false),
                        email_confirmed = c.Boolean(nullable: false),
                        user_name = c.String(nullable: false, maxLength: 50),
                        nick_name = c.String(nullable: false, maxLength: 50),
                        email = c.String(maxLength: 256),
                        is_valid = c.Boolean(nullable: false),
                        created_by_id = c.String(maxLength: 40),
                        created_time = c.DateTime(nullable: false),
                        last_modified_by_id = c.String(maxLength: 40),
                        last_modified_time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.hy_user");
            DropTable("dbo.hy_data_history");
        }
    }
}
