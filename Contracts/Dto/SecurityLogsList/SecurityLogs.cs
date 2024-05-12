using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dto.SecurityLogsList
{
    public class SecurityLogs
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Action { get; set; }
        public string? IpAdress { get; set; }
        public DateTime DateTime { get; set; }
        public string? Browser { get; set; }
        public bool IsSuccess { get; set; }

    }
}
