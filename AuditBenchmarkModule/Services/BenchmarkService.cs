using AuditBenchmarkModule.Models;
using AuditBenchmarkModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditBenchmarkModule.Providers
{
    public class BenchmarkService : IBenchmarkService
    {
        private readonly log4net.ILog log4netval;
        private IBenchmarkRepo objBenchmarkRepo;
        public BenchmarkService(IBenchmarkRepo objBenchmarkRepo)
        {
            log4netval = log4net.LogManager.GetLogger(typeof(BenchmarkService));
            this.objBenchmarkRepo = objBenchmarkRepo;
        }

        public List<AuditBenchmark> GetBenchmark()
        {
            log4netval.Info(" Http GET request " + nameof(BenchmarkService));

            List<AuditBenchmark> listOfRepository = new List<AuditBenchmark>();
            try
            {
                listOfRepository = objBenchmarkRepo.GetNolist();
                return listOfRepository;
            }
            catch (Exception e)
            {
                log4netval.Error(" Exception here" + e.Message + " " + nameof(BenchmarkService));
                return null;
            }

        }

    }
}
