namespace Kardf.Platform.Entities
{
    public class Field : EntityBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ControlType ControlType { get; set; }
        public QueryType QueryType { get; set; }
        public int Width { get; set; }
        public int Sequence { get; set; }
        public bool IsShow { get; set; }
        public bool IsExport { get; set; }
        public bool IsSort { get; set; }
    }
}
