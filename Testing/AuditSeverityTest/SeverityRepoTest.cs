using AuditSeverityModule.Controllers;
using AuditSeverityModule.Models;
using AuditSeverityModule.Services;
using AuditSeverityModule.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AuditSeverityTest
{
    class SeverityRepoTest
    {
        List<AuditBenchmark> l1 = new List<AuditBenchmark>();
        List<AuditBenchmark> l2 = null;
        [SetUp]
        public void setup()
        {

            l1 = new List<AuditBenchmark>()
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
        }
        [Test]
        public void GetSeverityResponse_ValidOutput_OkRequest()
        {
            Mock<ISeverityRepo> mock = new Mock<ISeverityRepo>();
            mock.Setup(p => p.GetResponse(It.IsAny<string>())).Returns(l1);

            SeverityRepo cp = new SeverityRepo();

            List<AuditBenchmark> result = cp.GetResponse("");
            Assert.AreEqual(l2, result);


        }

        [Test]
        public void GetSeverityResponse_InvalidOutput_BadRequestRequest()
        {
            Mock<ISeverityRepo> mock = new Mock<ISeverityRepo>();
            mock.Setup(p => p.GetResponse(It.IsAny<string>())).Returns(l2);

            SeverityRepo cp = new SeverityRepo();

            List<AuditBenchmark> result = cp.GetResponse("");
            Assert.IsNull(result);
        }

    }
}
