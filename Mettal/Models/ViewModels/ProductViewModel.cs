﻿using System.Collections.Generic;
using System.Web.Mvc;
using Mettal.Models.Entities;

namespace Mettal.Models.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }

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
        public int MarkId { get; set; }
        public List<Mark> Marks { get; set; }

        public int GostId { get; set; }
        public List<Gost> Gosts { get; set; }

        public int TargetId { get; set; }
        public List<Target> Targets { get; set; }

        public int CountryId { get; set; }
        public List<Country> Countries { get; set; }

        // dop
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
    }
}