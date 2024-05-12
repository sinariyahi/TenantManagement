using Contracts.Dto.AuditTrailsList;
using Contracts.Dto.DiffCoefficientList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.TenantManagement.DiffCoefficientList
{
    public interface IDiffCoefficientService
    {
        Task<bool> AddDiffCoefficient(DiffCoefficient diffCoefficient);
        Task<bool> UpdateDiffCoefficient(DiffCoefficient diffCoefficient);
        Task<DiffCoefficient> GetDiffCoefficientById(int id);
        Task<bool> DeleteDiffCoefficient(int id);
        Task<IEnumerable<DiffCoefficient>> GetDiffCoefficient();
    }
}
