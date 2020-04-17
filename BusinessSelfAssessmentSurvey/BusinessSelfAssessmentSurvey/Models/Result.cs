using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessSelfAssessmentSurvey.Models
{
    public class Result
    {
        public string question { get; set; }
        public string answer { get; set; }
        public string category { get; set; }
        public string other { get; set; }
    }
}