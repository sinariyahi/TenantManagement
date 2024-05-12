using Contracts.Dto.ProjectsList;
using Contracts.Dto.ProvincesList;
using Contracts.Interface.Shared;
using Contracts.Interface.TenantManagement.ProjectsList;
using Contracts.Interface.TenantManagement.ProvincesList;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.TenantManagement.ProvincesList
{
    public class ProvincesService : IProvincesService, IBaseService
    {
        private readonly IGenericRepository _repo;
        public ProvincesService(IGenericRepository repo)
        {
            _repo = repo;
        }
        

        public async Task<bool> AddProvinces(Provinces provinces)
        {
            try
            {
                string query = "insert into dbo.Provinces(Id,SequenceNumber,Name,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy) values(@Id,@SequenceNumber,@Name,@CreatedDate,@CreatedBy,@ModifiedDate,@ModifiedBy)";
                await _repo.SaveData(query, new { Id = provinces.Id, SequenceNumber = provinces.SequenceNumber, Name = provinces.Name, CreatedDate = provinces.CreatedDate, CreatedBy = provinces.CreatedBy, ModifiedDate = provinces.ModifiedDate, ModifiedBy = provinces.ModifiedBy });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateProvinces(Provinces provinces)
        {
            try
            {
                string query = "update dbo.Provinces set  SequenceNumber = @SequenceNumber, Name = @Name, CreatedDate = @CreatedDate, CreatedBy = @CreatedBy, ModifiedDate = @ModifiedDate, ModifiedBy = @ModifiedBy where Id=@Id";
                await _repo.SaveData(query, provinces);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProvinces(int id)
        {
            try
            {
                string query = "delete from dbo.Provinces where id = @Id";
                await _repo.SaveData(query, new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Provinces>> GetProvinces()
        {
            string query = "select * from dbo.Provinces";
            var provinces = await _repo.GetData<Provinces, dynamic>(query, new { });
            return provinces;
        }

        public async Task<Provinces> GetProvincesById(int id)
        {
            string query = "select * from dbo.Provinces where Id=@Id";
            IEnumerable<Provinces> provinces = await _repo.GetData<Provinces, dynamic>(query, new { Id = id });
            return provinces.FirstOrDefault();
        }
    }
}