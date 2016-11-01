using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mettal.Models.ViewModels
{
    public class ManualViewModel : BaseViewModel
    {
        [DisplayName("Название")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string HtmlContent { get; set; }
    }
}