using System;
using System.Collections.Generic;

namespace ErgonomicsDatabase.Models
{
    public partial class TStrengthData
    {
        public TStrengthData()
        {
            TStudy = new HashSet<TStudy>();
        }

        public int IStrengthDataId { get; set; }
        public double FMeanMale { get; set; }
        public double FMeanFemale { get; set; }
        public double FSdmale { get; set; }
        public double FSdfemale { get; set; }

        public virtual ICollection<TStudy> TStudy { get; set; }
    }
}
