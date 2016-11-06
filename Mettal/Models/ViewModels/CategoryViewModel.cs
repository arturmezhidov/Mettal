using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mettal.Models.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        [DisplayName("Название")]
        [Required(ErrorMessage = "Введите название")]
        public string DisplayName { get; set; }

        [DisplayName("Картинка")]
        public string ImagePath { get; set; }

        [DisplayName("Иконка")]
        public string IconPath { get; set; }

        [DisplayName("Короткое описание")]
        public string Description { get; set; }

        [DisplayName("Подробное описание")]
        public string HtmlContent { get; set; }

        [DisplayName("Таблица")]
        [Required(ErrorMessage = "Выберите таблицу")]
        public int? TableId { get; set; }

        public string ImageViewLink { get; set; }

        public HttpPostedFileBase Image { get; set; }

        public HttpPostedFileBase Icon { get; set; }

        public List<SelectListItem> Items { get; set; }
    }
}