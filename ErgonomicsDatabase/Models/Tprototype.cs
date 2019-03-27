using System;
using System.Collections.Generic;

namespace ErgonomicsDatabase.Models
{
    public partial class Tprototype
    {
        public Tprototype()
        {
            Tnotes = new HashSet<Tnotes>();
        }

        public int IprototypeId { get; set; }
        public string VcDataCollection { get; set; }
        public string VcPosture { get; set; }
        public string VcTorqueType { get; set; }
        public int IstudyYear { get; set; }

        public virtual ICollection<Tnotes> Tnotes { get; set; }
    }
}
