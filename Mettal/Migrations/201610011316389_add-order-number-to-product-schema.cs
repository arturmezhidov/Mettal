namespace Mettal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addordernumbertoproductschema : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductSchemas", "NameOrderNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ProductSchemas", "PriceOrderNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ProductSchemas", "SurfaceOrderNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ProductSchemas", "DescriptionOrderNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ProductSchemas", "LengthOrderNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ProductSchemas", "WidthOrderNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ProductSchemas", "HeightOrderNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ProductSchemas", "ThicknessOrderNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ProductSchemas", "StenkaOrderNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ProductSchemas", "DiameterOrderNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ProductSchemas", "SechenieOrderNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ProductSchemas", "WeightOrderNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ProductSchemas", "WeightOneOrderNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ProductSchemas", "WeightOneKgOrderNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ProductSchemas", "MarkOrderNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ProductSchemas", "GostOrderNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ProductSchemas", "TargetOrderNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ProductSchemas", "CountryOrderNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ProductSchemas", "CategoryOrderNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ProductSchemas", "Info1OrderNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ProductSchemas", "Info2OrderNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ProductSchemas", "Info3OrderNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductSchemas", "Info3OrderNumber");
            DropColumn("dbo.ProductSchemas", "Info2OrderNumber");
            DropColumn("dbo.ProductSchemas", "Info1OrderNumber");
            DropColumn("dbo.ProductSchemas", "CategoryOrderNumber");
            DropColumn("dbo.ProductSchemas", "CountryOrderNumber");
            DropColumn("dbo.ProductSchemas", "TargetOrderNumber");
            DropColumn("dbo.ProductSchemas", "GostOrderNumber");
            DropColumn("dbo.ProductSchemas", "MarkOrderNumber");
            DropColumn("dbo.ProductSchemas", "WeightOneKgOrderNumber");
            DropColumn("dbo.ProductSchemas", "WeightOneOrderNumber");
            DropColumn("dbo.ProductSchemas", "WeightOrderNumber");
            DropColumn("dbo.ProductSchemas", "SechenieOrderNumber");
            DropColumn("dbo.ProductSchemas", "DiameterOrderNumber");
            DropColumn("dbo.ProductSchemas", "StenkaOrderNumber");
            DropColumn("dbo.ProductSchemas", "ThicknessOrderNumber");
            DropColumn("dbo.ProductSchemas", "HeightOrderNumber");
            DropColumn("dbo.ProductSchemas", "WidthOrderNumber");
            DropColumn("dbo.ProductSchemas", "LengthOrderNumber");
            DropColumn("dbo.ProductSchemas", "DescriptionOrderNumber");
            DropColumn("dbo.ProductSchemas", "SurfaceOrderNumber");
            DropColumn("dbo.ProductSchemas", "PriceOrderNumber");
            DropColumn("dbo.ProductSchemas", "NameOrderNumber");
        }
    }
}
