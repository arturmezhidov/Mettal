namespace Mettal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class slideishidden : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Slides", "IsHidden", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Slides", "IsHidden", c => c.String());
        }
    }
}
