using System.Web;

namespace Mettal.Models.ViewModels
{
    public class SlideViewModel : BaseViewModel
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public bool IsHidden { get; set; }
        public int OrderNumber { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public bool IsFirst { get; set; }
        public bool IsLast { get; set; }
    }
}