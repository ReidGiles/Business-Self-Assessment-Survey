using System.Data.Entity;

namespace BusinessSelfAssessmentSurvey.Models
{
    public class SurveyContext : DbContext
    {
        public SurveyContext() : base("DefaultConnection")
        { }

        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }

        public DbSet<SurveyOption> SurveyOptions { get; set; }

        public DbSet<SurveyCategory> SurveyCategories { get; set; }

        public DbSet<SurveyRating> SurveyRatings { get; set; }
    }
}