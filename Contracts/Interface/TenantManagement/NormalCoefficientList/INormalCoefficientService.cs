using Contracts.Dto.ExceptionLogsList;
using Contracts.Dto.NormalCoefficientList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.TenantManagement.NormalCoefficientList
{
    public interface INormalCoefficientService
    {
        Task<bool> AddNormalCoefficient(NormalCoefficient normalCoefficient);
        Task<bool> UpdateNormalCoefficient(NormalCoefficient normalCoefficient);
        Task<NormalCoefficient> GetNormalCoefficientById(int id);
        Task<bool> DeleteNormalCoefficient(int id);
        Task<IEnumerable<NormalCoefficient>> GetNormalCoefficient();
    }
}
