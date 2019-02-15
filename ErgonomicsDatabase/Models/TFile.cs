using System;
using System.Collections.Generic;

namespace ErgonomicsDatabase.Models
{
    public partial class TFile
    {
        public TFile()
        {
            TObjectHandlePhoto = new HashSet<TObjectHandlePhoto>();
            TPosturePhoto = new HashSet<TPosturePhoto>();
        }

        public int IFileId { get; set; }
        public int IFileTypeId { get; set; }
        public string VcFileName { get; set; }
        public string VcFilePath { get; set; }
        public bool BArchived { get; set; }

        public virtual TFileType IFileType { get; set; }
        public virtual ICollection<TObjectHandlePhoto> TObjectHandlePhoto { get; set; }
        public virtual ICollection<TPosturePhoto> TPosturePhoto { get; set; }
    }
}
