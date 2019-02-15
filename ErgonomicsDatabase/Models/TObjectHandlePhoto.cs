using System;
using System.Collections.Generic;

namespace ErgonomicsDatabase.Models
{
    public partial class TObjectHandlePhoto
    {
        public int IObjectHandlePhotoId { get; set; }
        public int IObjectHandleId { get; set; }
        public int IFileId { get; set; }

        public virtual TFile IFile { get; set; }
    }
}
