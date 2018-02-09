using System;

namespace Kardf
{
    public class EntityBase
    {
        public string Oid { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateTime { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string Extension { get; set; }
    }
}
