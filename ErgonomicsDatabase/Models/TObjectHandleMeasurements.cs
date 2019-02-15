using System;
using System.Collections.Generic;

namespace ErgonomicsDatabase.Models
{
    public partial class TObjectHandleMeasurements
    {
        public long BiObjectHandleMeasurementsId { get; set; }
        public int IObjectHandleId { get; set; }
        public int IDimensionId { get; set; }
        public int IMeasurement { get; set; }
        public int IUnitId { get; set; }

        public virtual TDimension IDimension { get; set; }
        public virtual TObjectHandle IObjectHandle { get; set; }
        public virtual TUnit IUnit { get; set; }
    }
}
