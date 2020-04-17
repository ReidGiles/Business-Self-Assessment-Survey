using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusinessSelfAssessmentSurvey.Models
{
    public class SurveyRating
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Admin { get; set; }
        public int Business { get; set; }
        public int Architecture { get; set; }
        public int Development { get; set; }
        public int Security { get; set; }
        public int Documentation { get; set; }
        public int Compliance { get; set; }
        public int Processes { get; set; }
    }
}