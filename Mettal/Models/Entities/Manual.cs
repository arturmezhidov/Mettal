namespace Mettal.Models.Entities
{
    public class Manual : BaseEntity
    {
        public string Name { get; set; }
        public string HtmlContent { get; set; }
        public virtual ManualCategory Category { get; set; }
    }
}