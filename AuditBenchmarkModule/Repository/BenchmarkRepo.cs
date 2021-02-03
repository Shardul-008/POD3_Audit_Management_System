using AuditBenchmarkModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditBenchmarkModule.Repository
{
    public class BenchmarkRepo : IBenchmarkRepo
    {
        private static List<AuditBenchmark> auditBenchmarkList = new List<AuditBenchmark>()
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
        public List<AuditBenchmark> GetNolist()
        {
            List<AuditBenchmark> listOfCriteria = new List<AuditBenchmark>();
            try
            {
                listOfCriteria = auditBenchmarkList;
                return listOfCriteria;
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
