using System;
using System.Collections.Generic;

namespace ErgonomicsDatabase.Models
{
    public partial class TPosturePhoto
    {
        public int IPosturePhotoId { get; set; }
        public int IPostureId { get; set; }
        public int IFileId { get; set; }

        public virtual TFile IFile { get; set; }
        public virtual TPosture IPosture { get; set; }
    }
}
