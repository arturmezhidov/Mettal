namespace Mettal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Categories", name: "CategorySetting_Id", newName: "ProductSchema_Id");
            RenameIndex(table: "dbo.Categories", name: "IX_CategorySetting_Id", newName: "IX_ProductSchema_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Categories", name: "IX_ProductSchema_Id", newName: "IX_CategorySetting_Id");
            RenameColumn(table: "dbo.Categories", name: "ProductSchema_Id", newName: "CategorySetting_Id");
        }
    }
}
