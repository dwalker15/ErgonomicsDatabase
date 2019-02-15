using System;
using System.Collections.Generic;

namespace ErgonomicsDatabase.Models
{
    public partial class TStudy
    {
        public TStudy()
        {
            TStudySubject = new HashSet<TStudySubject>();
        }

        public int IStudyId { get; set; }
        public int IActionId { get; set; }
        public int IStrengthDataId { get; set; }
        public DateTime DtStudyYear { get; set; }
        public string VcSource { get; set; }
        public int IStudyFileId { get; set; }
        public bool BArchived { get; set; }

        public virtual TAction IAction { get; set; }
        public virtual TStrengthData IStrengthData { get; set; }
        public virtual ICollection<TStudySubject> TStudySubject { get; set; }
    }
}
