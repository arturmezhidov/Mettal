using System.Collections.Generic;

namespace Mettal.Models.Entities
{
    public class Mark : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Mark()
        {
            Products = new HashSet<Product>();
        }
    }
}