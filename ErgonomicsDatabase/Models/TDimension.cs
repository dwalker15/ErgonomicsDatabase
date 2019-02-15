using System;
using System.Collections.Generic;

namespace ErgonomicsDatabase.Models
{
    public partial class TDimension
    {
        public TDimension()
        {
            TObjectHandleMeasurements = new HashSet<TObjectHandleMeasurements>();
        }

        public int IDimensionId { get; set; }
        public string VcDimension { get; set; }

        public virtual ICollection<TObjectHandleMeasurements> TObjectHandleMeasurements { get; set; }
    }
}
