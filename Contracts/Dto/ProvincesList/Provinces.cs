using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dto.ProvincesList
{
    public class Provinces
    {
        public int Id { get; set; }
        public int SequenceNumber { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        
    }
}
