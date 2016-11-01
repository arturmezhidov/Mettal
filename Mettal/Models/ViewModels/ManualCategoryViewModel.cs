using System.Collections.Generic;

namespace Mettal.Models.ViewModels
{
    public class ManualCategoryViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public List<ManualViewModel> Manuals { get; set; }

        public ManualCategoryViewModel()
        {
            Manuals = new List<ManualViewModel>();
        }
    }
}