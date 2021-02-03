using AuditBenchmarkModule.Controllers;
using AuditBenchmarkModule.Models;
using AuditBenchmarkModule.Providers;
using AuditBenchmarkModule.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AuditBenchMarkTest
{
    public class Tests
    {
        List<AuditBenchmark> list1 = new List<AuditBenchmark>();
        List<AuditBenchmark> list2 = new List<AuditBenchmark>();
        [SetUp]
        public void Setup()
        {

            list1 = new List<AuditBenchmark>()
            {
               new AuditBenchmark
            {
                AuditType="Internal",
                BenchmarkNoAnswers=3
            },
                new AuditBenchmark
            {
                AuditType="SOX",
                BenchmarkNoAnswers=1
            }
            };
            list2 = new List<AuditBenchmark>()
            {
                new AuditBenchmark
                {
                    AuditType="ABC",
                    BenchmarkNoAnswers=4
                }
            };


        }


        [Test]
        public void GetAuditBenchmark_ValidInput_OkRequest()
        {
            Mock<IBenchmarkService> mock = new Mock<IBenchmarkService>();
            mock.Setup(p => p.GetBenchmark()).Returns(list1);
            AuditBenchmarkController cp = new AuditBenchmarkController(mock.Object);
            ObjectResult result = cp.GetAuditBenchmark() as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);

        }



        [Test]
        public void GetAuditBenchmark_InvalidInput_ReturnBadRequest()
        {
            try
            {
                Mock<IBenchmarkService> mock = new Mock<IBenchmarkService>();
                mock.Setup(p => p.GetBenchmark()).Returns(list2);
                AuditBenchmarkController cp = new AuditBenchmarkController(mock.Object);
                var result = cp.GetAuditBenchmark() as BadRequestResult;
                Assert.AreEqual(400, result.StatusCode);
            }

            catch (Exception e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }
        }
    }
}