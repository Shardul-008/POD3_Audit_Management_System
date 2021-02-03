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
    class SeverityServiceTest
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

        List<AuditBenchmark> list2 = new List<AuditBenchmark>()
        {
            new AuditBenchmark()
            {
                AuditType="Internal",
                BenchmarkNoAnswers=1
            },
            new AuditBenchmark()
            {
                AuditType="SOX",
                BenchmarkNoAnswers=0
            }
        };

        [Test]
        public void Internal_GetSeverityResponse_ValidOutput_OkRequest()
        {
            Mock<ISeverityRepo> mock = new Mock<ISeverityRepo>();
            mock.Setup(p => p.GetResponse(It.IsAny<string>())).Returns(list1);
            SeverityService cp = new SeverityService(mock.Object);
            AuditRequest req = new AuditRequest()
            {
                Auditdetails = new AuditDetail()
                {
                    Type = "Internal",
                    Questions = new Questions()
                    {
                        Question1 = true,
                        Question2 = true,
                        Question3 = false,
                        Question4 = false,
                        Question5 = true
                    }
                }
            };
            AuditResponse result = cp.GetSeverityResponse(req, "XYZ");
            Assert.AreEqual("GREEN", result.ProjectExexutionStatus);
        }
        [Test]
        public void SOX_GetSeverityResponse_ValidOutput_OkRequest()
        {
            Mock<ISeverityRepo> mock = new Mock<ISeverityRepo>();
            mock.Setup(p => p.GetResponse(It.IsAny<string>())).Returns(list1);
            SeverityService cp = new SeverityService(mock.Object);
            AuditRequest req = new AuditRequest()
            {
                Auditdetails = new AuditDetail()
                {
                    Type = "Internal",
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
            AuditResponse result = cp.GetSeverityResponse(req, "XYZ");
            Assert.AreEqual("RED", result.ProjectExexutionStatus);
        }

        [Test]
        public void Internal_GetSeverityResponse_InvalidOutput_BadRequest()
        {
            Mock<ISeverityRepo> mock = new Mock<ISeverityRepo>();
            mock.Setup(p => p.GetResponse(It.IsAny<string>())).Returns(list2);
            SeverityService cp = new SeverityService(mock.Object);
            AuditRequest req = new AuditRequest()
            {
                Auditdetails = new AuditDetail()
                {
                    Type = "Internal",
                    Questions = new Questions()
                    {
                        Question1 = true,
                        Question2 = true,
                        Question3 = false,
                        Question4 = false,
                        Question5 = true
                    }
                }
            };
            AuditResponse result = cp.GetSeverityResponse(req, "XYZ");
            Assert.AreNotEqual("GREEN", result.ProjectExexutionStatus);
        }
        [Test]
        public void SOX_GetSeverityResponse_InvalidOutput_BadRequest()
        {
            Mock<ISeverityRepo> mock = new Mock<ISeverityRepo>();
            mock.Setup(p => p.GetResponse(It.IsAny<string>())).Returns(list2);
            SeverityService cp = new SeverityService(mock.Object);
            AuditRequest req = new AuditRequest()
            {
                Auditdetails = new AuditDetail()
                {
                    Type = "Internal",
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
            AuditResponse result = cp.GetSeverityResponse(req, "token");
            Assert.AreNotEqual("Red", result.ProjectExexutionStatus);
        }
    }
}
