using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mettal.Models.ViewModels
{
    public class MarkViewModel : BaseViewModel
    {
        [DisplayName("Название")]
        [Required(ErrorMessage = "Обязательное поле для заполнения")]
        public string Name { get; set; }
    }
}