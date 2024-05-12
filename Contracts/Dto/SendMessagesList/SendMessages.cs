using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dto.SendMessagesList
{
    public class SendMessages
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int ProjectId { get; set; }
        public string? ProjectIds { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
