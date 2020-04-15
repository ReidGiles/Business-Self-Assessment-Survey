using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BusinessSelfAssessmentSurvey.Models
{
    public class SurveyDatabaseInitialiser : CreateDatabaseIfNotExists<SurveyContext>
    {
        /// <summary>
        /// Populate survey category, question and option data models
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(SurveyContext context)
        {
            base.Seed(context);

            List<SurveyCategory> surveyCategories = new List<SurveyCategory>();

            surveyCategories.Add(new SurveyCategory
            {
                Title = "Admin",
                SurveyQuestions = (new SurveyQuestion[]
                {
                    new SurveyQuestion { Title = "What is your company size? Size of your IT team (if any)", Options = GetOptions(4, new string[] { "1-5", "6-20", "21-50", "50+"}).ToList()},
                    new SurveyQuestion { Title = "What is your growth ambition? (turnover, geo presence, etc…)", Options = GetOptions(4, new string[] { "Turnover", "Geo Presence", "Other"}).ToList()}
                }).ToList()
            });

            surveyCategories.Add(new SurveyCategory
            {
                Title = "Business",
                SurveyQuestions = (new SurveyQuestion[]
                {
                    new SurveyQuestion { Title = "Do you own / maintain your own IT?", Options = GetOptions(2, new string[] { "Yes", "No"}).ToList()},
                    new SurveyQuestion { Title = "What is the size of your support team / of your IT team?", Options = GetOptions(4, new string[] { "1-5", "6-20", "21-50", "50+" }).ToList()}
                }).ToList()
            });

            surveyCategories.Add(new SurveyCategory
            {
                Title = "Architecture",
                SurveyQuestions = (new SurveyQuestion[]
                {
                    new SurveyQuestion { Title = "Do you maintain a series of documents / diagrams capturing your architecture?", Options = GetOptions(2, new string[] { "Yes", "No"}).ToList()},
                }).ToList()
            });

            surveyCategories.Add(new SurveyCategory
            {
                Title = "Development",
                SurveyQuestions = (new SurveyQuestion[]
                {
                    new SurveyQuestion { Title = "What is the size of your current development backlog", Options = GetOptions(4, new string[] { "1-5 Days", "6-30 Days", "30-90 Days", "90+ Days" }).ToList()},
                    new SurveyQuestion { Title = "What is your process for approving and developing new software products or features?", Options = GetOptions(1, new string[] { "N/A" }).ToList()}
                }).ToList()
            });

            surveyCategories.Add(new SurveyCategory
            {
                Title = "Security",
                SurveyQuestions = (new SurveyQuestion[]
                {
                    new SurveyQuestion { Title = "How is product security considered during product development?", Options = GetOptions(1, new string[] { "N/A" }).ToList()},
                }).ToList()
            });

            surveyCategories.Add(new SurveyCategory
            {
                Title = "Documentation",
                SurveyQuestions = (new SurveyQuestion[]
                {
                    new SurveyQuestion { Title = "Can you provide copies of your hosting / cloud service provider agreement?", Options = GetOptions(2, new string[] { "Yes", "No" }).ToList()},
                    new SurveyQuestion { Title = "Do you have a documented IT roadmap?", Options = GetOptions(2, new string[] { "Yes", "No" }).ToList()}
                }).ToList()
            });

            surveyCategories.Add(new SurveyCategory
            {
                Title = "Compliance",
                SurveyQuestions = (new SurveyQuestion[]
                {                  
                    new SurveyQuestion { Title = "How - what processes, people and technology measures, have you put in place to ensure compliance?", Options = GetOptions(1, new string[] { "N/A" }).ToList()},
                    new SurveyQuestion { Title = "Do you have Data Breach Incident & Notification Policy & Procedures?", Options = GetOptions(2, new string[] { "Yes", "No" }).ToList()}
                }).ToList()
            });
            
            surveyCategories.Add(new SurveyCategory
            {
                Title = "Processes",
                SurveyQuestions = (new SurveyQuestion[]
                {
                    new SurveyQuestion { Title = "Do you have a documented Support / incident runbook?", Options = GetOptions(2, new string[] { "Yes", "No" }).ToList()},
                }).ToList()
            });

            surveyCategories.ForEach(a => context.SurveyCategories.Add(a));
        }

        /// <summary>
        /// Generate an array of SurveyOptions from an array of strings and a length
        /// </summary>
        /// <param name="size"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        private SurveyOption[] GetOptions(int size, string[] options)
        {
            SurveyOption[] surveyOptions = new SurveyOption[size];

            for (int i = 0; i < surveyOptions.Length; i++)
            {
                surveyOptions[i].Title = options[i];
            }

            return surveyOptions;
        }
    }
}