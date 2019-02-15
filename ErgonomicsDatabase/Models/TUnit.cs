using System;
using System.Collections.Generic;

namespace ErgonomicsDatabase.Models
{
    public partial class TUnit
    {
        public TUnit()
        {
            TObjectHandleMeasurements = new HashSet<TObjectHandleMeasurements>();
        }

        public int IUnitId { get; set; }
        public string VcUnit { get; set; }

        public virtual ICollection<TObjectHandleMeasurements> TObjectHandleMeasurements { get; set; }
    }
}
