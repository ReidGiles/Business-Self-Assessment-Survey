using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessSelfAssessmentSurvey.Models;
using Newtonsoft.Json;

namespace BusinessSelfAssessmentSurvey.Controllers
{
    public class SurveyController : ApiController
    {
        private SurveyContext db = new SurveyContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }
            base.Dispose(disposing);
        }

        [ResponseType(typeof(SurveyCategory))]
        public async Task<IHttpActionResult> Get(int id)
        {
            SurveyCategory surveyCategory =  await NextSurveyCategory(id);
            return Ok(surveyCategory);
        }

        [ResponseType(typeof(SurveyCategory))]
        public async Task<IHttpActionResult> Get()
        {
            SurveyCategory[] surveyCategory = this.db.SurveyCategories.ToArray();
            return Ok(surveyCategory);
        }

        public void Post(Object model)
        {
            var jsonString = model.ToString();
            List<Result> result = JsonConvert.DeserializeObject<List<Result>>(jsonString);
        }

        private async Task<SurveyCategory> NextSurveyCategory(int id)
        {
            return await this.db.SurveyCategories.FindAsync(id);
        }
    }
}