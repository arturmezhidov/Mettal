using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mettal.Models.Business;
using Mettal.Models.Entities;

namespace Mettal.Models.ViewModels
{
    public class HomeView
    {
        public AppSettings Settings { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}