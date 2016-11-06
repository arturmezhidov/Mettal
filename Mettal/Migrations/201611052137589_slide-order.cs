namespace Mettal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class slideorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Slides", "OrderNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Slides", "OrderNumber");
        }
    }
}
