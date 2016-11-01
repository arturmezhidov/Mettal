namespace Mettal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manual : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ManualCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Manuals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HtmlContent = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ManualCategories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Manuals", "Category_Id", "dbo.ManualCategories");
            DropIndex("dbo.Manuals", new[] { "Category_Id" });
            DropTable("dbo.Manuals");
            DropTable("dbo.ManualCategories");
        }
    }
}
