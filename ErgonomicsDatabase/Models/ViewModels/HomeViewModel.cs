﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ErgonomicsDatabase.Models.ViewModels
{
    public class HomeViewModel
    {
        public int HandleID { get; set; }
        public List<SelectListItem> Handles { get; set; }

        public int PostureID { get; set; }
        public List<SelectListItem> Postures { get; set; }

        public int RotationID { get; set; }
        public List<SelectListItem> Rotations { get; set; }

        public int HandID { get; set; }
        public List<SelectListItem> Hands { get; set; }

        public int AxisID { get; set; }
        public List<SelectListItem> Axes { get; set; }
    }
}
