using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dto.SuggestionsList
{
    public class Suggestions
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int TenantId { get; set; }
        public string Message { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsSolved { get; set; }
        public string? Explanation { get; set; }
        public int? SolvedBy { get; set; }
    }
}
