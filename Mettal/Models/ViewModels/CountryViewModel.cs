using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mettal.Models.ViewModels
{
    public class CountryViewModel : BaseViewModel
    {
        [DisplayName("Название")]
        [Required(ErrorMessage = "Обязательное поле для заполнения")]
        public string Name { get; set; }
    }
}