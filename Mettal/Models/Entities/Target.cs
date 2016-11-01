using System.Collections.Generic;

namespace Mettal.Models.Entities
{
    public class Target : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Target()
        {
            Products = new HashSet<Product>();
        }
    }
}