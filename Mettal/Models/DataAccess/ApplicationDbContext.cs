using System.Data.Entity;
using Mettal.Models.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Mettal.Models.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ProductSchema> ProductSchemas { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Gost> Gosts { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Target> Targets { get; set; }
        public virtual DbSet<ManualCategory> ManualCategories { get; set; }
        public virtual DbSet<Manual> Manuals { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }

        public ApplicationDbContext()
            : base(AppConfig.ConnectionStringName, throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}