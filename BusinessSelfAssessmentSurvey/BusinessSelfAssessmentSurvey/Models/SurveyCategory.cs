using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessSelfAssessmentSurvey.Models
{
    public class SurveyCategory
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual List<SurveyQuestion> SurveyQuestions { get; set; }
    }
}