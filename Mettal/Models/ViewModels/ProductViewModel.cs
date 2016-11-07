using System.Collections.Generic;
using System.Web.Mvc;
using Mettal.Models.Entities;

namespace Mettal.Models.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public Table Table { get; set; }
        public CategoryViewModel Category { get; set; }

        // common
        public string Name { get; set; }
        public double Price { get; set; }
        public string Surface { get; set; }
        public string Description { get; set; }

        // sizes
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Thickness { get; set; }
        public double Stenka { get; set; }
        public double Diameter { get; set; }
        public double Sechenie { get; set; }

        // weights
        public double Weight { get; set; }
        public double WeightOne { get; set; }
        public double WeightOneKg { get; set; }

        // navigate
        public int Mark { get; set; }
        public List<SelectListItem> Marks { get; set; }

        public int Gost { get; set; }
        public List<SelectListItem> Gosts { get; set; }

        public int Target { get; set; }
        public List<SelectListItem> Targets { get; set; }

        public int Country { get; set; }
        public List<SelectListItem> Countries { get; set; }

        // dop
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
    }
}