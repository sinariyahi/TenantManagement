using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.Security
{
    public interface IAuthenticationRepository
    {
        Task<List<object>> GetUser(string userName);
    }
}
