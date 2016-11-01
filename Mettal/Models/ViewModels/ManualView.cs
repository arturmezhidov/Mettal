using System.Collections.Generic;
using Mettal.Models.Business;

namespace Mettal.Models.ViewModels
{
    public class ManualView
    {
        public AppSettings Settings { get; set; }
        public List<ManualCategoryViewModel> Categories { get; set; }
    }
}