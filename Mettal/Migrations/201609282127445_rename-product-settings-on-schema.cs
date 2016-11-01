namespace Mettal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameproductsettingsonschema : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CategorySettings", newName: "ProductSchemas");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ProductSchemas", newName: "CategorySettings");
        }
    }
}
