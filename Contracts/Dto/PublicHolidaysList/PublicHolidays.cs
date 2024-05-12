using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dto.PublicHolidaysList
{
    public class PublicHolidays
    {
        public int Id { get; set; }
        public DateTime? Tarih { get; set; }
        public string? Explanation { get; set; }
        public int Type { get; set; }

    }
}
