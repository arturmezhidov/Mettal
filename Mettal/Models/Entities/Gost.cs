using System.Collections.Generic;

namespace Mettal.Models.Entities
{
    public class Gost : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Gost()
        {
            Products = new HashSet<Product>();
        }
    }
}