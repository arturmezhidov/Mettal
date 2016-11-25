using System.ComponentModel.DataAnnotations;

namespace Mettal.Models.ViewModels
{
    public class CallbackViewModel
    {
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        public string Phone { get; set; }
    }
}