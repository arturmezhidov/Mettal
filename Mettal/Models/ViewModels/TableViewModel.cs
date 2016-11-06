using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mettal.Models.ViewModels
{
    public class TableViewModel : BaseViewModel
    {
        [DisplayName("Название таблицы")]
        [Required(ErrorMessage = "Название таблицы обязательно для заполнения")]
        public string TableName { get; set; }

        // common
        [DisplayName("Название")]
        public string NameTitle { get; set; }
        public bool NameIsShow { get; set; }
        public int NameOrderNumber { get; set; }

        [DisplayName("Цена")]
        public string PriceTitle { get; set; }
        public bool PriceIsShow { get; set; }
        public int PriceOrderNumber { get; set; }

        [DisplayName("Поверхность")]
        public string SurfaceTitle { get; set; }
        public bool SurfaceIsShow { get; set; }
        public int SurfaceOrderNumber { get; set; }

        [DisplayName("Описание")]
        public string DescriptionTitle { get; set; }
        public bool DescriptionIsShow { get; set; }
        public int DescriptionOrderNumber { get; set; }

        // sizes
        [DisplayName("Длина")]
        public string LengthTitle { get; set; }
        public bool LengthIsShow { get; set; }
        public int LengthOrderNumber { get; set; }

        [DisplayName("Ширина")]
        public string WidthTitle { get; set; }
        public bool WidthIsShow { get; set; }
        public int WidthOrderNumber { get; set; }

        [DisplayName("Высота")]
        public string HeightTitle { get; set; }
        public bool HeightIsShow { get; set; }
        public int HeightOrderNumber { get; set; }

        [DisplayName("Толщина")]
        public string ThicknessTitle { get; set; }
        public bool ThicknessIsShow { get; set; }
        public int ThicknessOrderNumber { get; set; }

        [DisplayName("Стенка")]
        public string StenkaTitle { get; set; }
        public bool StenkaIsShow { get; set; }
        public int StenkaOrderNumber { get; set; }

        [DisplayName("Диаметр")]
        public string DiameterTitle { get; set; }
        public bool DiameterIsShow { get; set; }
        public int DiameterOrderNumber { get; set; }

        [DisplayName("Сечение")]
        public string SechenieTitle { get; set; }
        public bool SechenieIsShow { get; set; }
        public int SechenieOrderNumber { get; set; }

        // weights
        [DisplayName("Вес")]
        public string WeightTitle { get; set; }
        public bool WeightIsShow { get; set; }
        public int WeightOrderNumber { get; set; }

        [DisplayName("Вес 1 шт")]
        public string WeightOneTitle { get; set; }
        public bool WeightOneIsShow { get; set; }
        public int WeightOneOrderNumber { get; set; }

        [DisplayName("Вес 1 м")]
        public string WeightOneKgTitle { get; set; }
        public bool WeightOneKgIsShow { get; set; }
        public int WeightOneKgOrderNumber { get; set; }

        // navigate
        [DisplayName("Марка")]
        public string MarkTitle { get; set; }
        public bool MarkIsShow { get; set; }
        public int MarkOrderNumber { get; set; }

        [DisplayName("ГОСТ")]
        public string GostTitle { get; set; }
        public bool GostIsShow { get; set; }
        public int GostOrderNumber { get; set; }

        [DisplayName("Цель")]
        public string TargetTitle { get; set; }
        public bool TargetIsShow { get; set; }
        public int TargetOrderNumber { get; set; }

        [DisplayName("Страна")]
        public string CountryTitle { get; set; }
        public bool CountryIsShow { get; set; }
        public int CountryOrderNumber { get; set; }

        [DisplayName("Категория")]
        public string CategoryTitle { get; set; }
        public bool CategoryIsShow { get; set; }
        public int CategoryOrderNumber { get; set; }

        // dop
        [DisplayName("Информация 1")]
        public string Info1Title { get; set; }
        public bool Info1IsShow { get; set; }
        public int Info1OrderNumber { get; set; }

        [DisplayName("Информация 2")]
        public string Info2Title { get; set; }
        public bool Info2IsShow { get; set; }
        public int Info2OrderNumber { get; set; }

        [DisplayName("Информация 3")]
        public string Info3Title { get; set; }
        public bool Info3IsShow { get; set; }
        public int Info3OrderNumber { get; set; }
    }
}