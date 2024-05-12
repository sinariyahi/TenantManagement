using Contracts.Dto.ProjectsList;
using Contracts.Dto.ProvincesList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.TenantManagement.ProvincesList
{
    public interface IProvincesService
    {
        Task<bool> AddProvinces(Provinces provinces);
        Task<bool> UpdateProvinces(Provinces provinces);
        Task<Provinces> GetProvincesById(int id);
        Task<bool> DeleteProvinces(int id);
        Task<IEnumerable<Provinces>> GetProvinces();
    }
}
