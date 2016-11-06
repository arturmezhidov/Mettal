namespace Mettal.Models.Entities
{
    public class Slide : BaseEntity
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public bool IsHidden { get; set; }
        public int OrderNumber { get; set; }
    }
}