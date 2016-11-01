namespace Mettal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(),
                        ImagePath = c.String(),
                        IconPath = c.String(),
                        Description = c.String(),
                        HtmlContent = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CategorySetting_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategorySettings", t => t.CategorySetting_Id)
                .Index(t => t.CategorySetting_Id);
            
            CreateTable(
                "dbo.CategorySettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameTitle = c.String(),
                        NameIsShow = c.String(),
                        PriceTitle = c.String(),
                        PriceIsShow = c.String(),
                        SurfaceTitle = c.String(),
                        SurfaceIsShow = c.String(),
                        DescriptionTitle = c.String(),
                        DescriptionIsShow = c.String(),
                        LengthTitle = c.String(),
                        LengthIsShow = c.String(),
                        WidthTitle = c.String(),
                        WidthIsShow = c.String(),
                        HeightTitle = c.String(),
                        HeightIsShow = c.String(),
                        ThicknessTitle = c.String(),
                        ThicknessIsShow = c.String(),
                        StenkaTitle = c.String(),
                        StenkaIsShow = c.String(),
                        DiameterTitle = c.String(),
                        DiameterIsShow = c.String(),
                        SechenieTitle = c.String(),
                        SechenieIsShow = c.String(),
                        WeightTitle = c.String(),
                        WeightIsShow = c.String(),
                        WeightOneTitle = c.String(),
                        WeightOneIsShow = c.String(),
                        WeightOneKgTitle = c.String(),
                        WeightOneKgIsShow = c.String(),
                        MarkTitle = c.String(),
                        MarkIsShow = c.String(),
                        GostTitle = c.String(),
                        GostIsShow = c.String(),
                        TargetTitle = c.String(),
                        TargetIsShow = c.String(),
                        CountryTitle = c.String(),
                        CountryIsShow = c.String(),
                        CategoryTitle = c.String(),
                        CategoryIsShow = c.String(),
                        Info1Title = c.String(),
                        Info1IsShow = c.String(),
                        Info2Title = c.String(),
                        Info2IsShow = c.String(),
                        Info3Title = c.String(),
                        Info3IsShow = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Surface = c.String(),
                        Description = c.String(),
                        Length = c.Double(nullable: false),
                        Width = c.Double(nullable: false),
                        Height = c.Double(nullable: false),
                        Thickness = c.Double(nullable: false),
                        Stenka = c.Double(nullable: false),
                        Diameter = c.Double(nullable: false),
                        Sechenie = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        WeightOne = c.Double(nullable: false),
                        WeightOneKg = c.Double(nullable: false),
                        Info1 = c.String(),
                        Info2 = c.String(),
                        Info3 = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Category_Id = c.Int(),
                        Country_Id = c.Int(),
                        Gost_Id = c.Int(),
                        Mark_Id = c.Int(),
                        Target_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .ForeignKey("dbo.Gosts", t => t.Gost_Id)
                .ForeignKey("dbo.Marks", t => t.Mark_Id)
                .ForeignKey("dbo.Targets", t => t.Target_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Country_Id)
                .Index(t => t.Gost_Id)
                .Index(t => t.Mark_Id)
                .Index(t => t.Target_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Targets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Value = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Products", "Target_Id", "dbo.Targets");
            DropForeignKey("dbo.Products", "Mark_Id", "dbo.Marks");
            DropForeignKey("dbo.Products", "Gost_Id", "dbo.Gosts");
            DropForeignKey("dbo.Products", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Categories", "CategorySetting_Id", "dbo.CategorySettings");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Products", new[] { "Target_Id" });
            DropIndex("dbo.Products", new[] { "Mark_Id" });
            DropIndex("dbo.Products", new[] { "Gost_Id" });
            DropIndex("dbo.Products", new[] { "Country_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.Categories", new[] { "CategorySetting_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Settings");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Targets");
            DropTable("dbo.Marks");
            DropTable("dbo.Gosts");
            DropTable("dbo.Countries");
            DropTable("dbo.Products");
            DropTable("dbo.CategorySettings");
            DropTable("dbo.Categories");
        }
    }
}
