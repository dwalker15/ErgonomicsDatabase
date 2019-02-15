using System;
using System.Collections.Generic;

namespace ErgonomicsDatabase.Models
{
    public partial class TPosture
    {
        public TPosture()
        {
            TAction = new HashSet<TAction>();
            TPosturePhoto = new HashSet<TPosturePhoto>();
        }

        public int IPostureId { get; set; }
        public string VcPostureDetails { get; set; }

        public virtual ICollection<TAction> TAction { get; set; }
        public virtual ICollection<TPosturePhoto> TPosturePhoto { get; set; }
    }
}
