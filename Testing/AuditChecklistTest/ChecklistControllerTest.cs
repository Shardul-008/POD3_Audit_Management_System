using NUnit.Framework;
using Moq;
using AuditChecklistModule.Controllers;
using AuditChecklistModule.Models;
using AuditChecklistModule.Providers;
using AuditChecklistModule.Repository;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AuditChecklistTest
{
    public class Tests
    {
        List<Questions> l1 = new List<Questions>();
        List<Questions> l2 = null;
        [SetUp]
        public void setup()
        {

            l1 = new List<Questions>()
            {
                new Questions
                {
                    QuestionNo=1,
                    Question="Have all Change requests followed SDLC before PROD move?"
                },
                new Questions
                {
                    QuestionNo=2,
                    Question="Have all Change requests been approved by the application owner?"
                },
                new Questions
                {
                    QuestionNo=3,
                    Question="Is data deletion from the system done with application owner approval?"
                }


            };
        }

   
        [TestCase("Internal")]
        [TestCase("SOX")]
        public void GetAuditCheckListQuestions_HasValidData_ReturnsOK(string type)
        {
            Mock<IChecklistService> mock = new Mock<IChecklistService>();
            mock.Setup(p => p.GetQuestionList(type)).Returns(l1);
            AuditChecklistController cp = new AuditChecklistController(mock.Object);
            OkObjectResult result = cp.GetAuditCheckListQuestions(type) as OkObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestCase("Internalab")]
        [TestCase("SOXab")]
        public void GetAuditCheckListQuestions_HasInvalidData_ReturnsBadRequest(string a)
        {
            try
            {
                string type = null;
                Mock<IChecklistService> mock = new Mock<IChecklistService>();
                mock.Setup(p => p.GetQuestionList(type)).Returns(l2);
                AuditChecklistController cp = new AuditChecklistController(mock.Object);
                OkObjectResult result = cp.GetAuditCheckListQuestions(type) as OkObjectResult;
                Assert.AreEqual(400, result.StatusCode);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

        }
    }
}