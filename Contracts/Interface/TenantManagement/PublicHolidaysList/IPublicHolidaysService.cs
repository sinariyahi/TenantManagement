using Contracts.Dto.ProvincesList;
using Contracts.Dto.PublicHolidaysList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.TenantManagement.PublicHolidaysList
{
    public interface IPublicHolidaysService
    {
        Task<bool> AddPublicHolidays(PublicHolidays publicHolidays);
        Task<bool> UpdatePublicHolidays(PublicHolidays publicHolidays);
        Task<PublicHolidays> GetPublicHolidaysById(int id);
        Task<bool> DeletePublicHolidays(int id);
        Task<IEnumerable<PublicHolidays>> GetPublicHolidays();
    }
}
