namespace Kardf.Platform.Entities
{
    public class Button : EntityBase
    {
        public string ParentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Action { get; set; }
        public string Icon { get; set; }
        public int Sequence { get; set; }
    }
}
