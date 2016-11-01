namespace Mettal.Models.Entities
{
    public class Product : BaseEntity
    {
        // common
        public string Name { get; set; }
        public double Price { get; set; }
        public string Surface { get; set; }
        public string Description { get; set; }

        // sizes
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Thickness { get; set; }
        public double Stenka { get; set; }
        public double Diameter { get; set; }
        public double Sechenie { get; set; }
       
        // weights
        public double Weight { get; set; }
        public double WeightOne { get; set; }
        public double WeightOneKg { get; set; }

        // navigate
        public virtual Mark Mark { get; set; }
        public virtual Gost Gost { get; set; }
        public virtual Target Target { get; set; }
        public virtual Country Country { get; set; }
        public virtual Category Category { get; set; }

        // dop
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
    }
}