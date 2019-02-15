using System;
using System.Collections.Generic;

namespace ErgonomicsDatabase.Models
{
    public partial class THand
    {
        public THand()
        {
            THandedness = new HashSet<THandedness>();
        }

        public int IHandId { get; set; }
        public string VcHand { get; set; }

        public virtual ICollection<THandedness> THandedness { get; set; }
    }
}
