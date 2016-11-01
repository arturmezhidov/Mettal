using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mettal.Models.Entities
{
    public class Slide : BaseEntity
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string IsHidden { get; set; }
    }
}