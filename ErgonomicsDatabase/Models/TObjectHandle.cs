using System;
using System.Collections.Generic;

namespace ErgonomicsDatabase.Models
{
    public partial class TObjectHandle
    {
        public TObjectHandle()
        {
            TAction = new HashSet<TAction>();
            TObjectHandleMeasurements = new HashSet<TObjectHandleMeasurements>();
        }

        public int IObjectHandleId { get; set; }
        public string VcObjectHandle { get; set; }
        public byte TiRotationAxisId { get; set; }

        public virtual TRotationAxis TiRotationAxis { get; set; }
        public virtual ICollection<TAction> TAction { get; set; }
        public virtual ICollection<TObjectHandleMeasurements> TObjectHandleMeasurements { get; set; }
    }
}
