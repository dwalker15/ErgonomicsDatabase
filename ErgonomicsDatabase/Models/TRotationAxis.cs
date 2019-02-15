using System;
using System.Collections.Generic;

namespace ErgonomicsDatabase.Models
{
    public partial class TRotationAxis
    {
        public TRotationAxis()
        {
            TObjectHandle = new HashSet<TObjectHandle>();
        }

        public byte TiRotationAxisId { get; set; }
        public string VcRotationAxis { get; set; }

        public virtual ICollection<TObjectHandle> TObjectHandle { get; set; }
    }
}
