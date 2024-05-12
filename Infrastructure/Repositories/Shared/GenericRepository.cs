using Common.DBHelper;
using Contracts;
using Contracts.Interface.Shared;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infrastructure.Repositories.Shared
{
    public class GenericRepository : IGenericRepository
    {

        private readonly IConnectionUtility connectionUtility;
        public GenericRepository(IConnectionUtility connectionUtility)
        {
            this.connectionUtility = connectionUtility;
        }
        // this method will retuarn a list of type T
        public async Task<IEnumerable<T>> GetData<T, P>(string query, P parameters)
        {
            using (var dapper = connectionUtility.NewConnection())
            return await dapper.QueryAsync<T>(query, parameters);

        }

        //This method will not return anything
        public async Task SaveData<P>(string query, P parameters)
        {
            using (var dapper = connectionUtility.NewConnection())
                await dapper.ExecuteAsync(query, parameters);

        }
    }
}

