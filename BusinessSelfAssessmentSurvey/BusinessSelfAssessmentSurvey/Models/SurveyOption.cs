using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace BusinessSelfAssessmentSurvey.Models
{
    public class SurveyOption
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Key, Column(Order = 0), ForeignKey("SurveyQuestion")]
        public int QuestionID { get; set; }

        [JsonIgnore]
        public virtual SurveyQuestion SurveyQuestion { get; set; }
    }
}