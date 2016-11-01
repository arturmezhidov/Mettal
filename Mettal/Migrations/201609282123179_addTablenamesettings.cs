namespace Mettal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTablenamesettings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CategorySettings", "TableName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CategorySettings", "TableName");
        }
    }
}
