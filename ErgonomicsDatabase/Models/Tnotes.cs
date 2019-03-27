using System;
using System.Collections.Generic;

namespace ErgonomicsDatabase.Models
{
    public partial class Tnotes
    {
        public int InoteId { get; set; }
        public int IprototypeId { get; set; }
        public string VcNote { get; set; }

        public virtual Tprototype Iprototype { get; set; }
    }
}
