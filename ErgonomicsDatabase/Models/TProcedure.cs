using System;
using System.Collections.Generic;

namespace ErgonomicsDatabase.Models
{
    public partial class TProcedure
    {
        public TProcedure()
        {
            TAction = new HashSet<TAction>();
        }

        public int IProcedureId { get; set; }
        public string VcProcedure { get; set; }

        public virtual ICollection<TAction> TAction { get; set; }
    }
}
