using Contracts.Dto.SendMessagesList;
using Contracts.Dto.ServersList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.TenantManagement.ServersList
{
    public interface IServersService
    {
        Task<bool> AddServers(Servers servers);
        Task<bool> UpdateServers(Servers servers);
        Task<Servers> GetServersById(int id);
        Task<bool> DeleteServers(int id);
        Task<IEnumerable<Servers>> GetServers();
    }
}
