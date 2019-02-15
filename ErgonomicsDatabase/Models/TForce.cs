using System;
using System.Collections.Generic;

namespace ErgonomicsDatabase.Models
{
    public partial class TForce
    {
        public TForce()
        {
            TAction = new HashSet<TAction>();
        }

        public int IForceId { get; set; }
        public int IForceTypeId { get; set; }

        public virtual TForceType IForceType { get; set; }
        public virtual ICollection<TAction> TAction { get; set; }
    }
}
