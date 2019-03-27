using System;
using System.Collections.Generic;

namespace ErgonomicsDatabase.Models
{
    public partial class SysUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }
        public string UserPassword { get; set; }
    }
}
