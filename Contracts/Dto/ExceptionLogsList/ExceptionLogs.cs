using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dto.ExceptionLogsList
{
    public class ExceptionLogs
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int TenantId { get; set; }
        public DateTime DateTime { get; set; }
        public string? Controller { get; set; }
        public string? Request { get; set; }
        public string? Exception { get; set; }
        public bool IsSolved { get; set; }
        public string? Explanation { get; set; }
        public int? SolvedBy { get; set; }
    }
}
