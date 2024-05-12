using Contracts.Dto.SuggestionsList;
using Contracts.Dto.TefeEndeksList;
using Contracts.Interface.Shared;
using Contracts.Interface.TenantManagement.SuggestionsList;
using Contracts.Interface.TenantManagement.TefeEndeksList;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.TenantManagement.TefeEndeksList
{
    public class TefeEndeksService : ITefeEndeksService, IBaseService
    {
        private readonly IGenericRepository _repo;
        public TefeEndeksService(IGenericRepository repo)
        {
            _repo = repo;
        }


        public async Task<bool> AddTefeEndeks(TefeEndeks tefeEndeks)
        {
            try
            {
                string query = "insert into dbo.TefeEndeks(yil,oran1,oran2,oran3,oran4,oran5,oran6,oran7,oran8,oran9,oran10,oran11,oran12,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy) values(@yil,@oran1,@oran2,@oran3,@oran4,@oran5,@oran6,@oran7,@oran8,@oran9,@oran10,@oran11,@oran12,@CreatedDate,@CreatedBy,@ModifiedDate,@ModifiedBy)";
                await _repo.SaveData(query, new { yil = tefeEndeks.yil, oran1 = tefeEndeks.oran1, oran2 = tefeEndeks.oran2, oran3 = tefeEndeks.oran3, oran4 = tefeEndeks.oran4, oran5 = tefeEndeks.oran5, oran6 = tefeEndeks.oran6, oran7 = tefeEndeks.oran7, oran8 = tefeEndeks.oran8, oran9 = tefeEndeks.oran9, oran10 = tefeEndeks.oran10, oran11 = tefeEndeks.oran11, oran12 = tefeEndeks.oran12, CreatedDate = tefeEndeks.CreatedDate, CreatedBy = tefeEndeks.CreatedBy, ModifiedDate = tefeEndeks.ModifiedDate, ModifiedBy = tefeEndeks.ModifiedBy });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateTefeEndeks(TefeEndeks tefeEndeks)
        {
            try
            {
                string query = "update dbo.TefeEndeks set  yil = @yil, oran1 = @oran1, oran2 = @oran2, oran3 = @oran3, oran4 = @oran4, oran5 = @oran5, oran6 = @oran6, oran7 = @oran7, oran8 = @oran8, oran9 = @oran9, oran10 = @oran10, oran11 = @oran11, oran12 = @oran12, CreatedDate = @CreatedDate, CreatedBy = @CreatedBy, ModifiedDate = @ModifiedDate, ModifiedBy = @ModifiedBy where Id=@Id";
                await _repo.SaveData(query, tefeEndeks);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteTefeEndeks(int id)
        {
            try
            {
                string query = "delete from dbo.TefeEndeks where id = @Id";
                await _repo.SaveData(query, new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<TefeEndeks>> GetTefeEndeks()
        {
            string query = "select * from dbo.TefeEndeks";
            var tefeEndeks = await _repo.GetData<TefeEndeks, dynamic>(query, new { });
            return tefeEndeks;
        }

        public async Task<TefeEndeks> GetTefeEndeksById(int id)
        {
            string query = "select * from dbo.TefeEndeks where Id=@Id";
            IEnumerable<TefeEndeks> tefeEndeks = await _repo.GetData<TefeEndeks, dynamic>(query, new { Id = id });
            return tefeEndeks.FirstOrDefault();
        }


    }

}
