using System;
using System.Collections.Generic;

namespace ErgonomicsDatabase.Models
{
    public partial class TSubject
    {
        public TSubject()
        {
            TStudySubject = new HashSet<TStudySubject>();
        }

        public int ISubjectId { get; set; }
        public byte TiMaleSubjectCount { get; set; }
        public byte TiFemaleSubjectCount { get; set; }
        public string VcSubjectDescription { get; set; }
        public byte TiSubjectAgeRangeBegin { get; set; }
        public byte TiSubjectAgeRangeEnd { get; set; }

        public virtual ICollection<TStudySubject> TStudySubject { get; set; }
    }
}
