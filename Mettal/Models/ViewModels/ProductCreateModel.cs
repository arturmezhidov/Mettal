using System.Collections.Generic;
using Mettal.Models.Entities;

namespace Mettal.Models.ViewModels
{
    public class ProductCreateModel
    {
        public Category Category { get; set; }
        public List<ProductViewModel> Products { get; set; }

        public ProductCreateModel()
        {
            Products = new List<ProductViewModel>();
        }
    }
}