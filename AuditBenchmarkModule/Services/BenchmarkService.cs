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
        private IBenchmarkRepo objBenchmarkRepo;
        public BenchmarkService(IBenchmarkRepo objBenchmarkRepo)
        {
            this.objBenchmarkRepo = objBenchmarkRepo;
        }

        public List<AuditBenchmark> GetBenchmark()
        {

            List<AuditBenchmark> listOfRepository = new List<AuditBenchmark>();
            try
            {
                listOfRepository = objBenchmarkRepo.GetNolist();
                return listOfRepository;
            }
            catch (Exception e)
            {
                return null;
            }

        }

    }
}
