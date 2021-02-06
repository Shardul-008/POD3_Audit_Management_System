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
    class BenchmarkServiceTest
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
        public void GetBenchmark_ValidInput_OkRequest()
        {
            Mock<IBenchmarkRepo> mock = new Mock<IBenchmarkRepo>();
            mock.Setup(p => p.GetNolist()).Returns(list1);
            BenchmarkService cp = new BenchmarkService(mock.Object);
            List<AuditBenchmark> result = cp.GetBenchmark();
            Assert.AreEqual(list1.Count, result.Count);
        }

        [Test]
        public void GetBenchmark_InvalidInput_ReturnBadRequest()
        {
            Mock<IBenchmarkRepo> mock = new Mock<IBenchmarkRepo>();
            mock.Setup(p => p.GetNolist()).Returns(list2);
            BenchmarkService cp = new BenchmarkService(mock.Object);
            List<AuditBenchmark> result = cp.GetBenchmark();
            Assert.AreNotEqual(list1.Count, result.Count);
        }
    }
}
