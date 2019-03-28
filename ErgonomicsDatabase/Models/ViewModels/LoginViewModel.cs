using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ErgonomicsDatabase.Models.ViewModels
{
    public class LoginViewModel
    {
        public string name { get; set; }
        public string registerEmail { get; set; }
        public string registerPassword { get; set; }
    }
}
