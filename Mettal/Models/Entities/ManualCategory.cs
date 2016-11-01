using System.Collections.Generic;

namespace Mettal.Models.Entities
{
    public class ManualCategory : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Manual> Manuals { get; set; }

        public ManualCategory()
        {
            Manuals = new HashSet<Manual>();
        }
    }
}