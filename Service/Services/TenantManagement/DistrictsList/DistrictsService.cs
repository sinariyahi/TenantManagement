using Contracts.Dto.DiffCoefficientList;
using Contracts.Dto.DistrictsList;
using Contracts.Interface.Shared;
using Contracts.Interface.TenantManagement.DiffCoefficientList;
using Contracts.Interface.TenantManagement.DistrictsList;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.TenantManagement.DistrictsList
{
    public class DistrictsService : IDistrictsService, IBaseService
    {
        private readonly IGenericRepository _repo;
        public DistrictsService(IGenericRepository repo)
        {
            _repo = repo;
        }
        

        public async Task<bool> AddDistricts(Districts districts)
        {
            try
            {
                string query = "insert into dbo.Districts(Id,SequenceNumber,Name,ProvinceId,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy) values(@Id,@SequenceNumber,@Name,@ProvinceId,@CreatedDate,@CreatedBy,@ModifiedDate,@ModifiedBy)";
                await _repo.SaveData(query, new { Id = districts.Id, SequenceNumber = districts.SequenceNumber, Name = districts.Name, ProvinceId = districts.ProvinceId, CreatedDate = districts.CreatedDate, CreatedBy = districts.CreatedBy, ModifiedDate = districts.ModifiedDate, ModifiedBy = districts.ModifiedBy });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateDistricts(Districts districts)
        {
            try
            {
                string query = "update dbo.Districts set  SequenceNumber = @SequenceNumber, Name = @Name, ProvinceId = @ProvinceId, CreatedDate = @CreatedDate, CreatedBy = @CreatedBy, ModifiedDate = @ModifiedDate, ModifiedBy = @ModifiedBy where Id=@Id";
                await _repo.SaveData(query, districts);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteDistricts(int id)
        {
            try
            {
                string query = "delete from dbo.Districts where id = @Id";
                await _repo.SaveData(query, new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Districts>> GetDistricts()
        {
            string query = "select * from dbo.Districts";
            var districts = await _repo.GetData<Districts, dynamic>(query, new { });
            return districts;
        }

        public async Task<Districts> GetDistrictsById(int id)
        {
            string query = "select * from dbo.Districts where Id=@Id";
            IEnumerable<Districts> districts = await _repo.GetData<Districts, dynamic>(query, new { Id = id });
            return districts.FirstOrDefault();
        }
    }
}

