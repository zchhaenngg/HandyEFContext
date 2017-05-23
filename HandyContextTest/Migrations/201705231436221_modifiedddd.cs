namespace HandyContextTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedddd : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.hy_auth_role", new[] { "Creator_id" });
            DropIndex("dbo.hy_auth_role", new[] { "hy_user_id" });
            CreateTable(
                "dbo.HistoryFields",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 40),
                        UniqueKey = c.String(nullable: false, maxLength: 40),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedById = c.String(maxLength: 40),
                        CreatedTime = c.DateTime(nullable: false),
                        LastModifiedById = c.String(maxLength: 40),
                        LastModifiedTime = c.DateTime(nullable: false),
                        Table_Id = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HistoryTables", t => t.Table_Id)
                .Index(t => t.Table_Id);
            
            CreateTable(
                "dbo.HistoryTables",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 40),
                        Name = c.String(maxLength: 128),
                        CreatedById = c.String(maxLength: 40),
                        CreatedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.HistoryFieldValues",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 40),
                        Value = c.String(),
                        CreatedById = c.String(maxLength: 40),
                        CreatedTime = c.DateTime(nullable: false),
                        Field_Id = c.String(nullable: false, maxLength: 40),
                        LogEvent_Id = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HistoryFields", t => t.Field_Id, cascadeDelete: true)
                .ForeignKey("dbo.LogEvents", t => t.LogEvent_Id)
                .Index(t => t.Field_Id)
                .Index(t => t.LogEvent_Id);
            
            CreateTable(
                "dbo.LogEvents",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 40),
                        SessionId = c.Long(),
                        CreatedById = c.String(maxLength: 40),
                        CreatedTime = c.DateTime(nullable: false),
                        EventType_Id = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LogEventTypes", t => t.EventType_Id)
                .Index(t => t.EventType_Id);
            
            CreateTable(
                "dbo.LogEventTypes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 40),
                        Name = c.String(),
                        CreatedById = c.String(maxLength: 40),
                        CreatedTime = c.DateTime(nullable: false),
                        LastModifiedById = c.String(maxLength: 40),
                        LastModifiedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.hy_user", "CreatedById", c => c.String(maxLength: 40));
            AddColumn("dbo.hy_user", "CreatedTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.hy_user", "LastModifiedById", c => c.String(maxLength: 40));
            AddColumn("dbo.hy_user", "LastModifiedTime", c => c.DateTime(nullable: false));
            CreateIndex("dbo.hy_auth_role", "Creator_Id");
            CreateIndex("dbo.hy_auth_role", "hy_user_Id");
            DropColumn("dbo.hy_user", "created_by_id");
            DropColumn("dbo.hy_user", "created_time");
            DropColumn("dbo.hy_user", "last_modified_by_id");
            DropColumn("dbo.hy_user", "last_modified_time");
            DropTable("dbo.hy_data_history");
        }
        
        public override void Down()
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
                        context_id = c.String(nullable: false, maxLength: 40),
                        created_by_id = c.String(maxLength: 40),
                        created_time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.hy_user", "last_modified_time", c => c.DateTime(nullable: false));
            AddColumn("dbo.hy_user", "last_modified_by_id", c => c.String(maxLength: 40));
            AddColumn("dbo.hy_user", "created_time", c => c.DateTime(nullable: false));
            AddColumn("dbo.hy_user", "created_by_id", c => c.String(maxLength: 40));
            DropForeignKey("dbo.HistoryFieldValues", "LogEvent_Id", "dbo.LogEvents");
            DropForeignKey("dbo.LogEvents", "EventType_Id", "dbo.LogEventTypes");
            DropForeignKey("dbo.HistoryFieldValues", "Field_Id", "dbo.HistoryFields");
            DropForeignKey("dbo.HistoryFields", "Table_Id", "dbo.HistoryTables");
            DropIndex("dbo.hy_auth_role", new[] { "hy_user_Id" });
            DropIndex("dbo.hy_auth_role", new[] { "Creator_Id" });
            DropIndex("dbo.LogEvents", new[] { "EventType_Id" });
            DropIndex("dbo.HistoryFieldValues", new[] { "LogEvent_Id" });
            DropIndex("dbo.HistoryFieldValues", new[] { "Field_Id" });
            DropIndex("dbo.HistoryTables", new[] { "Name" });
            DropIndex("dbo.HistoryFields", new[] { "Table_Id" });
            DropColumn("dbo.hy_user", "LastModifiedTime");
            DropColumn("dbo.hy_user", "LastModifiedById");
            DropColumn("dbo.hy_user", "CreatedTime");
            DropColumn("dbo.hy_user", "CreatedById");
            DropTable("dbo.LogEventTypes");
            DropTable("dbo.LogEvents");
            DropTable("dbo.HistoryFieldValues");
            DropTable("dbo.HistoryTables");
            DropTable("dbo.HistoryFields");
            CreateIndex("dbo.hy_auth_role", "hy_user_id");
            CreateIndex("dbo.hy_auth_role", "Creator_id");
        }
    }
}
