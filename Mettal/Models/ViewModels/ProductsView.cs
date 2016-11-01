using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mettal.Models.Business;

namespace Mettal.Models.ViewModels
{
    public class ProductsView1
    {
        public AppSettings Settings { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}