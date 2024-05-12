using Contracts.Dto.AuditTrailsList;
using Contracts.Dto.DiffCoefficientList;
using Contracts.Dto.DistrictsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.TenantManagement.DistrictsList
{
    public interface IDistrictsService
    {
        Task<bool> AddDistricts(Districts districts);
        Task<bool> UpdateDistricts(Districts districts);
        Task<Districts> GetDistrictsById(int id);
        Task<bool> DeleteDistricts(int id);
        Task<IEnumerable<Districts>> GetDistricts();
    }
}
