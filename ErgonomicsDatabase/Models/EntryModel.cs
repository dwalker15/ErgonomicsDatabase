using System;
namespace ErgonomicsDatabase.Models
{
    public class EntryModel
    {
        public string torqueType { get; set; }
        public string posture { get; set; }
        public string notes { get; set; }
        public string objectHandle { get; set; }
        public string dataCollection { get; set; }
        public double maleMean { get; set; }
        public double maleSD { get; set; }
        public double femaleMean { get; set; }
        public double femaleSD { get; set; }
        public int femaleNumber { get; set; }
        public int maleNumber { get; set; }
        public int ageMin { get; set; }
        public int ageMax { get; set; }
        public string subjectDescription { get; set; }
        public string rotationAxis { get; set; }
        public string hand { get; set; }
        public bool isDominant { get; set; }
        public int year { get; set; }
        public string source { get; set; }
    }
}
