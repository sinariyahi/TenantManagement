using Contracts.Dto.TefeEndeksList;
using Contracts.Dto.TenantsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.TenantManagement.TenantsList
{
    public interface ITenantsService
    {
        Task<bool> AddTenants(Tenants tenants);
        Task<bool> UpdateTenants(Tenants tenants);
        Task<Tenants> GetTenantsById(int id);
        Task<bool> DeleteTenants(int id);
        Task<IEnumerable<Tenants>> GetTenants();
    }
}
