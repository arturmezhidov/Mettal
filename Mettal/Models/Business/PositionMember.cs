using System.Collections.Generic;

namespace Mettal.Models.Business
{
    public class PositionMember
    {
        public string Title { get; set; }
        public int OrderNumber { get; set; }
        public List<object> Values { get; set; }

        public PositionMember()
        {
            Values = new List<object>();
        }
    }
}