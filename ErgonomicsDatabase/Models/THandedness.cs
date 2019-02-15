using System;
using System.Collections.Generic;

namespace ErgonomicsDatabase.Models
{
    public partial class THandedness
    {
        public THandedness()
        {
            TAction = new HashSet<TAction>();
        }

        public int IHandednessId { get; set; }
        public int IHandId { get; set; }
        public bool BIsDominant { get; set; }

        public virtual THand IHand { get; set; }
        public virtual ICollection<TAction> TAction { get; set; }
    }
}
