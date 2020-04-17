using BusinessSelfAssessmentSurvey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessSelfAssessmentSurvey
{
    public class SurveyRatingGenerator
    {
        private List<Result> _result;

        private Dictionary<string, int> _resultDictionary;

        public SurveyRating GetRating(List<Result> result)
        {
            _result = result;
            _resultDictionary = new Dictionary<string, int>();
            SurveyRating surveyRating = new SurveyRating();

            foreach (Result r in _result)
            {
                if (_resultDictionary.ContainsKey(r.Category))
                {
                    _resultDictionary[r.Category] = _resultDictionary[r.Category] + r.Rating;
                }
                else
                {
                    _resultDictionary.Add(r.Category, r.Rating);
                }
            }

            foreach (string key in _resultDictionary.Keys)
            {
                switch (key)
                {
                    case nameof(surveyRating.Admin):
                        surveyRating.Admin = _resultDictionary[key];
                        break;
                    case nameof(surveyRating.Business):
                        surveyRating.Business = _resultDictionary[key];
                        break;
                    case nameof(surveyRating.Architecture):
                        surveyRating.Architecture = _resultDictionary[key];
                        break;
                    case nameof(surveyRating.Development):
                        surveyRating.Development = _resultDictionary[key];
                        break;
                    case nameof(surveyRating.Security):
                        surveyRating.Security = _resultDictionary[key];
                        break;
                    case nameof(surveyRating.Documentation):
                        surveyRating.Documentation = _resultDictionary[key];
                        break;
                    case nameof(surveyRating.Compliance):
                        surveyRating.Compliance = _resultDictionary[key];
                        break;
                    case nameof(surveyRating.Processes):
                        surveyRating.Processes = _resultDictionary[key];
                        break;
                    default:
                        // code block
                        break;
                }
            }


            return surveyRating;
        }
    }
}