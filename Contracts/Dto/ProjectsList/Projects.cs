using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dto.ProjectsList
{
    public class Projects
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Version { get; set; }
        public string Name { get; set; }
        public string ProjectUrl { get; set; }
        public string? ProjectCode { get; set; }
        public string? ProjectName { get; set; }
        public string? Explanation { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool IsActive { get; set; } 
    }
}
