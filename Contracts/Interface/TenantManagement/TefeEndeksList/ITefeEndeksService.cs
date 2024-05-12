using Contracts.Dto.SuggestionsList;
using Contracts.Dto.TefeEndeksList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.TenantManagement.TefeEndeksList
{
    public interface ITefeEndeksService
    {
        Task<bool> AddTefeEndeks(TefeEndeks tefeEndeks);
        Task<bool> UpdateTefeEndeks(TefeEndeks tefeEndeks);
        Task<TefeEndeks> GetTefeEndeksById(int id);
        Task<bool> DeleteTefeEndeks(int id);
        Task<IEnumerable<TefeEndeks>> GetTefeEndeks();
    }
}
