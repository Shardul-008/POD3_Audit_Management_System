using AuditBenchmarkModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditBenchmarkModule.Repository
{
    public class BenchmarkRepo : IBenchmarkRepo
    {
        private readonly log4net.ILog log4netval = log4net.LogManager.GetLogger(typeof(BenchmarkRepo));
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
            log4netval.Info(" Http GET request " + nameof(BenchmarkRepo));

            List<AuditBenchmark> listOfCriteria = new List<AuditBenchmark>();
            try
            {
                listOfCriteria = auditBenchmarkList;
                return listOfCriteria;
            }
            catch (Exception e)
            {
                log4netval.Error(" Exception here" + e.Message + " " + nameof(BenchmarkRepo));
                return null;
            }

        }
    }
}
