using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditBenchmarkModule.Models
{
    public class AuditBenchmark
    {
        public string AuditType { get; set; }
        public int BenchmarkNoAnswers { get; set; }
        // override object.Equals
        public override bool Equals(Object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            AuditBenchmark benchmark = obj as AuditBenchmark;
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // TODO: write your implementation of Equals() here
            if (this.AuditType == benchmark.AuditType && this.BenchmarkNoAnswers == benchmark.BenchmarkNoAnswers)
                return true;
            else
                return false;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            return base.GetHashCode();
        }
    }
}
