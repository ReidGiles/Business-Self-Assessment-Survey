using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusinessSelfAssessmentSurvey.Models
{
    public class Result
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Category { get; set; }
        public string Other { get; set; }
        public int Rating { get; set; }
    }
}