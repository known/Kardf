using Kardf.Extensions;
using System;

namespace Kardf
{
    public class EntityBase
    {
        public string Id { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateTime { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string Extension { get; set; }
    }

    public class EntityBase<T> : EntityBase
    {
        public virtual T ExtensionInfo
        {
            get { return Extension.FromJson<T>(); }
            set { Extension = value.ToJson(); }
        }
    }
}
