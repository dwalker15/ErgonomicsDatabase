using System;
using System.Collections.Generic;

namespace ErgonomicsDatabase.Models
{
    public partial class TForceType
    {
        public TForceType()
        {
            TForce = new HashSet<TForce>();
        }

        public int IForceTypeId { get; set; }
        public string VcForce { get; set; }

        public virtual ICollection<TForce> TForce { get; set; }
    }
}
