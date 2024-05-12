using Contracts.Dto.ServersList;
using Contracts.Dto.SuggestionsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.TenantManagement.SuggestionsList
{
    public interface ISuggestionsService
    {
        Task<bool> AddSuggestions(Suggestions suggestions);
        Task<bool> UpdateSuggestions(Suggestions suggestions);
        Task<Suggestions> GetSuggestionsById(int id);
        Task<bool> DeleteSuggestions(int id);
        Task<IEnumerable<Suggestions>> GetSuggestions();
    }
}
