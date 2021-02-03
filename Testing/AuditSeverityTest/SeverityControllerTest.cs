using AuditSeverityModule.Controllers;
using AuditSeverityModule.Models;
using AuditSeverityModule.Services;
using AuditSeverityModule.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AuditSeverityTest
{
    public class Tests
    {
        List<AuditBenchmark> list1 = new List<AuditBenchmark>()
        {
            new AuditBenchmark()
            {
                AuditType="Internal",
                BenchmarkNoAnswers=3
            },
            new AuditBenchmark()
            {
                AuditType="SOX",
                BenchmarkNoAnswers=1
            }
        };





        [TestCase("Internal")]
        [TestCase("SOX")]
        public void GetProjectExecutionStatus_ValidOutput_OkRequest(string type)
        {
            Mock<ISeverityService> mock = new Mock<ISeverityService>();
            AuditResponse rp = new AuditResponse();
            AuditRequest req = new AuditRequest()
            {
                Auditdetails = new AuditDetail()
                {
                    Type = type,
                    Questions = new Questions()
                    {
                        Question1 = true,
                        Question2 = false,
                        Question3 = false,
                        Question4 = false,
                        Question5 = false
                    }
                }
            };
            mock.Setup(p => p.GetSeverityResponse(req, It.IsAny<string>())).Returns(rp);
            AuditSeverityController cp = new AuditSeverityController(mock.Object);

            OkObjectResult result = cp.GetProjectExecutionStatus(req) as OkObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestCase("Internal123")]
        [TestCase("SOX123")]
        public void GetProjectExecutionStatus_InvalidOutput_ReturnBadRequest(string type)
        {
            try
            {
                Mock<ISeverityService> mock = new Mock<ISeverityService>();
                AuditResponse rp = new AuditResponse();
                AuditRequest req = new AuditRequest()
                {
                    Auditdetails = new AuditDetail()
                    {
                        Type = type,
                        Questions = new Questions()
                        {
                            Question1 = true,
                            Question2 = false,
                            Question3 = false,
                            Question4 = false,
                            Question5 = false
                        }
                    }
                };
                string token = "XYZ";
                mock.Setup(p => p.GetSeverityResponse(req, token)).Returns(rp);
                AuditSeverityController cp = new AuditSeverityController(mock.Object);

                OkObjectResult result = cp.GetProjectExecutionStatus(req) as OkObjectResult;
                Assert.AreEqual(400, result.StatusCode);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

        }
    }
}