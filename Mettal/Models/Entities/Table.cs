using System.Collections.Generic;

namespace Mettal.Models.Entities
{
    public class Table : BaseEntity
    {
        public string TableName { get; set; }

        // common
        public string NameTitle { get; set; }
        public bool NameIsShow { get; set; }
        public int NameOrderNumber { get; set; }

        public string PriceTitle { get; set; }
        public bool PriceIsShow { get; set; }
        public int PriceOrderNumber { get; set; }

        public string SurfaceTitle { get; set; }
        public bool SurfaceIsShow { get; set; }
        public int SurfaceOrderNumber { get; set; }

        public string DescriptionTitle { get; set; }
        public bool DescriptionIsShow { get; set; }
        public int DescriptionOrderNumber { get; set; }

        // sizes
        public string LengthTitle { get; set; }
        public bool LengthIsShow { get; set; }
        public int LengthOrderNumber { get; set; }

        public string WidthTitle { get; set; }
        public bool WidthIsShow { get; set; }
        public int WidthOrderNumber { get; set; }

        public string HeightTitle { get; set; }
        public bool HeightIsShow { get; set; }
        public int HeightOrderNumber { get; set; }

        public string ThicknessTitle { get; set; }
        public bool ThicknessIsShow { get; set; }
        public int ThicknessOrderNumber { get; set; }

        public string StenkaTitle { get; set; }
        public bool StenkaIsShow { get; set; }
        public int StenkaOrderNumber { get; set; }

        public string DiameterTitle { get; set; }
        public bool DiameterIsShow { get; set; }
        public int DiameterOrderNumber { get; set; }

        public string SechenieTitle { get; set; }
        public bool SechenieIsShow { get; set; }
        public int SechenieOrderNumber { get; set; }

        // weights
        public string WeightTitle { get; set; }
        public bool WeightIsShow { get; set; }
        public int WeightOrderNumber { get; set; }

        public string WeightOneTitle { get; set; }
        public bool WeightOneIsShow { get; set; }
        public int WeightOneOrderNumber { get; set; }

        public string WeightOneKgTitle { get; set; }
        public bool WeightOneKgIsShow { get; set; }
        public int WeightOneKgOrderNumber { get; set; }

        // navigate
        public string MarkTitle { get; set; }
        public bool MarkIsShow { get; set; }
        public int MarkOrderNumber { get; set; }

        public string GostTitle { get; set; }
        public bool GostIsShow { get; set; }
        public int GostOrderNumber { get; set; }

        public string TargetTitle { get; set; }
        public bool TargetIsShow { get; set; }
        public int TargetOrderNumber { get; set; }

        public string CountryTitle { get; set; }
        public bool CountryIsShow { get; set; }
        public int CountryOrderNumber { get; set; }

        public string CategoryTitle { get; set; }
        public bool CategoryIsShow { get; set; }
        public int CategoryOrderNumber { get; set; }

        // dop
        public string Info1Title { get; set; }
        public bool Info1IsShow { get; set; }
        public int Info1OrderNumber { get; set; }

        public string Info2Title { get; set; }
        public bool Info2IsShow { get; set; }
        public int Info2OrderNumber { get; set; }

        public string Info3Title { get; set; }
        public bool Info3IsShow { get; set; }
        public int Info3OrderNumber { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public Table()
        {
            Categories = new HashSet<Category>();
        }
    }
}