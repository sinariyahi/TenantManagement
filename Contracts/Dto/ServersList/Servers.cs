using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dto.ServersList
{
    public class Servers
    {
        public int Id { get; set; }
        public int OwnerType { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? Modifiedby { get; set; }
        public string? IpAddress { get; set; }
        public string? AdminUserName { get; set; }
        public string? AdminPassword { get; set; }
    }
}
