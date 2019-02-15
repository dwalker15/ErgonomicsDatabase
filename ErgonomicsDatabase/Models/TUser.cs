using System;
using System.Collections.Generic;

namespace ErgonomicsDatabase.Models
{
    public partial class TUser
    {
        public int IUserId { get; set; }
        public string VcUsername { get; set; }
        public string VcEmailAddress { get; set; }
        public string VcPassword { get; set; }
        public bool BArchived { get; set; }
    }
}
