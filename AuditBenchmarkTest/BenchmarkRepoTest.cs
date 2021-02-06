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
    class BenchmarkRepoTest
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
            BenchmarkRepo cp = new BenchmarkRepo();
            List<AuditBenchmark> result = cp.GetNolist();
            Assert.AreEqual(list1, result);
        }

        [Test]
        public void GetBenchmark_InvalidInput_ReturnBadRequest()
        {
            BenchmarkRepo cp = new BenchmarkRepo();
            List<AuditBenchmark> result = cp.GetNolist();
            Assert.AreNotEqual(list2.Count, result.Count);
        }
    }
}
