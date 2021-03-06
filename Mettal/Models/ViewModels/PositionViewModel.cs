﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mettal.Models.ViewModels
{
    public class PositionViewModel : BaseViewModel
    {
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
        public string Mark { get; set; }
        public string Gost { get; set; }
        public string Target { get; set; }
        public string Country { get; set; }

        // dop
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
    }
}