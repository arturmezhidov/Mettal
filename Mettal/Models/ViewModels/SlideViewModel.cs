using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mettal.Models.ViewModels
{
    public class SlideViewModel : BaseViewModel
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string IsHidden { get; set; }
    }
}