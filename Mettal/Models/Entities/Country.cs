using System.Collections.Generic;

namespace Mettal.Models.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Country()
        {
            Products = new HashSet<Product>();
        }
    }
}