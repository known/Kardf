﻿namespace Kardf.Platform.Entities
{
    public class Module : EntityBase
    {
        public string ParentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int Sequence { get; set; }
    }
}
