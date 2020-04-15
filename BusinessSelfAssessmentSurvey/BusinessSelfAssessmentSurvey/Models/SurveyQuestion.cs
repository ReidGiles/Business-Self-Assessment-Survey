using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessSelfAssessmentSurvey.Models
{
    public class SurveyQuestion
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual List<SurveyOption> Options { get; set; }
    }
}