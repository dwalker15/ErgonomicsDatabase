using System;
using System.Collections.Generic;

namespace ErgonomicsDatabase.Models
{
    public partial class TStudySubject
    {
        public int IStudySubjectId { get; set; }
        public int IStudyId { get; set; }
        public int ISubjectId { get; set; }

        public virtual TStudy IStudy { get; set; }
        public virtual TSubject ISubject { get; set; }
    }
}
