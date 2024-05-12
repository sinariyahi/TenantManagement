using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.Shared
{
    public interface IGenericRepository
    {
        Task<IEnumerable<T>> GetData<T, P>(string query, P parameters);
        Task SaveData<P>(string query, P parameters);
    }
}
