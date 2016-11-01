namespace Mettal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecolumntypeis___inproductschema : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductSchemas", "NameIsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductSchemas", "PriceIsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductSchemas", "SurfaceIsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductSchemas", "DescriptionIsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductSchemas", "LengthIsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductSchemas", "WidthIsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductSchemas", "HeightIsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductSchemas", "ThicknessIsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductSchemas", "StenkaIsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductSchemas", "DiameterIsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductSchemas", "SechenieIsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductSchemas", "WeightIsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductSchemas", "WeightOneIsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductSchemas", "WeightOneKgIsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductSchemas", "MarkIsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductSchemas", "GostIsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductSchemas", "TargetIsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductSchemas", "CountryIsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductSchemas", "CategoryIsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductSchemas", "Info1IsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductSchemas", "Info2IsShow", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductSchemas", "Info3IsShow", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductSchemas", "Info3IsShow", c => c.String());
            AlterColumn("dbo.ProductSchemas", "Info2IsShow", c => c.String());
            AlterColumn("dbo.ProductSchemas", "Info1IsShow", c => c.String());
            AlterColumn("dbo.ProductSchemas", "CategoryIsShow", c => c.String());
            AlterColumn("dbo.ProductSchemas", "CountryIsShow", c => c.String());
            AlterColumn("dbo.ProductSchemas", "TargetIsShow", c => c.String());
            AlterColumn("dbo.ProductSchemas", "GostIsShow", c => c.String());
            AlterColumn("dbo.ProductSchemas", "MarkIsShow", c => c.String());
            AlterColumn("dbo.ProductSchemas", "WeightOneKgIsShow", c => c.String());
            AlterColumn("dbo.ProductSchemas", "WeightOneIsShow", c => c.String());
            AlterColumn("dbo.ProductSchemas", "WeightIsShow", c => c.String());
            AlterColumn("dbo.ProductSchemas", "SechenieIsShow", c => c.String());
            AlterColumn("dbo.ProductSchemas", "DiameterIsShow", c => c.String());
            AlterColumn("dbo.ProductSchemas", "StenkaIsShow", c => c.String());
            AlterColumn("dbo.ProductSchemas", "ThicknessIsShow", c => c.String());
            AlterColumn("dbo.ProductSchemas", "HeightIsShow", c => c.String());
            AlterColumn("dbo.ProductSchemas", "WidthIsShow", c => c.String());
            AlterColumn("dbo.ProductSchemas", "LengthIsShow", c => c.String());
            AlterColumn("dbo.ProductSchemas", "DescriptionIsShow", c => c.String());
            AlterColumn("dbo.ProductSchemas", "SurfaceIsShow", c => c.String());
            AlterColumn("dbo.ProductSchemas", "PriceIsShow", c => c.String());
            AlterColumn("dbo.ProductSchemas", "NameIsShow", c => c.String());
        }
    }
}
