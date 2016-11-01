using System.Collections.Generic;

namespace Mettal.Models.Entities
{
    public class Category : BaseEntity
    {
        public string DisplayName { get; set; }
        public string ImagePath { get; set; }
        public string IconPath { get; set; }
        public string Description { get; set; }
        public string HtmlContent { get; set; }
        public int ProductSchemaId { get; set; }
        public virtual ProductSchema ProductSchema { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            Products = new HashSet<Product>();
        }
    }
}