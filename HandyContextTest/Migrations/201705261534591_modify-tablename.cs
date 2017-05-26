namespace HandyContextTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifytablename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.HistoryFields", newName: "HistoryField");
            RenameTable(name: "dbo.HistoryTables", newName: "HistoryTable");
            RenameTable(name: "dbo.HistoryFieldValues", newName: "HistoryFieldValue");
            RenameTable(name: "dbo.LogEvents", newName: "LogEvent");
            RenameTable(name: "dbo.LogEventTypes", newName: "LogEventType");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.LogEventType", newName: "LogEventTypes");
            RenameTable(name: "dbo.LogEvent", newName: "LogEvents");
            RenameTable(name: "dbo.HistoryFieldValue", newName: "HistoryFieldValues");
            RenameTable(name: "dbo.HistoryTable", newName: "HistoryTables");
            RenameTable(name: "dbo.HistoryField", newName: "HistoryFields");
        }
    }
}
