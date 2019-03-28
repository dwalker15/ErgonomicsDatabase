using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ErgonomicsDatabase.Models.ViewModels
{
    public class TorqueTableViewModel
    {
        public string ObjectHandle { get; set; }
        public string RotationAxis { get; set; }
        public string Posture { get; set; }
        public string Hand { get; set; }
        public int FemaleCount { get; set; }
        public int MaleCount { get; set; }
        public int BeginAgeRange { get; set; }
        public int EndAgeRange { get; set; }
        public int MeanFemale { get; set; }
        public int SDFemale { get; set; }
        public int MeanMale { get; set; }
        public int SDMale { get; set; }
        public string Source { get; set; }
        
        //public TorqueTableViewModel()
        //{
        //}
    }
}
