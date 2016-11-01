namespace Mettal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "ProductSchema_Id", "dbo.ProductSchemas");
            DropIndex("dbo.Categories", new[] { "ProductSchema_Id" });
            RenameColumn(table: "dbo.Categories", name: "ProductSchema_Id", newName: "ProductSchemaId");
            AlterColumn("dbo.Categories", "ProductSchemaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Categories", "ProductSchemaId");
            AddForeignKey("dbo.Categories", "ProductSchemaId", "dbo.ProductSchemas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "ProductSchemaId", "dbo.ProductSchemas");
            DropIndex("dbo.Categories", new[] { "ProductSchemaId" });
            AlterColumn("dbo.Categories", "ProductSchemaId", c => c.Int());
            RenameColumn(table: "dbo.Categories", name: "ProductSchemaId", newName: "ProductSchema_Id");
            CreateIndex("dbo.Categories", "ProductSchema_Id");
            AddForeignKey("dbo.Categories", "ProductSchema_Id", "dbo.ProductSchemas", "Id");
        }
    }
}
