using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessSelfAssessmentSurvey.Models;
using BusinessSelfAssessmentSurvey.Controllers;
using System.Net.Http;
using System.Net;

namespace UnitTests
{
    /// <summary>
    /// Miserably incomplete. Templated with how I would approach back end unit tests with more time.
    /// </summary>
    [TestClass]
    public class APITests
    {
        [TestMethod]
        public void GetWithValidID()
        {
            // Arange
            // Expected results

            // Act
            // API calls

            // Assert
            // Expected results vs API response
        }

        [TestMethod]
        public void GetWithIInvalidID()
        {
            // Arange
            // Expected results

            // Act
            // API calls

            // Assert
            // Expected results vs API response
        }

        [TestMethod]
        public void PostWithValidModel()
        {
            // Arange
            // Expected results

            // Act
            // API calls

            // Assert
            // Expected results vs API response
        }

        [TestMethod]
        public void PostWithInvalidModel()
        {
            // Arange
            // Expected results

            // Act
            // API calls

            // Assert
            // Expected results vs API response
        }
    }
}