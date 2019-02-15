using System;
using System.Collections.Generic;

namespace ErgonomicsDatabase.Models
{
    public partial class TFileType
    {
        public TFileType()
        {
            TFile = new HashSet<TFile>();
        }

        public int IFileTypeId { get; set; }
        public string VcFileType { get; set; }

        public virtual ICollection<TFile> TFile { get; set; }
    }
}
