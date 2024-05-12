using Contracts.Dto.DistrictsList;
using Contracts.Dto.ProvincesList;
using Contracts.Dto.ServersList;
using Contracts.Dto.TefeEndeksList;
using Contracts.Dto.TenantsList;
using Contracts.Interface.Shared;
using Contracts.Interface.TenantManagement.TefeEndeksList;
using Contracts.Interface.TenantManagement.TenantsList;
using Microsoft.AspNetCore.Http.HttpResults;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service.Services.TenantManagement.TenantsList
{
    public class TenantsService : ITenantsService, IBaseService
    {
        private readonly IGenericRepository _repo;
        public TenantsService(IGenericRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> AddTenants(Tenants tenants)
        {
            try
            {
                string query = "insert into dbo.Tenants(Id,CreationDate,ServerId,Code,TypeId,Name,Address,ProvinceId,DistrictId,PhoneNumber,Email,TaxOffice,TaxNumber,Administration,AuthorizedName,AuthorizedPhoneNumber,AuthorizedEmail,Explanation,DatabaseTypeId,IsSharedDatabase,ConnectionString,IsOnlyTenant,IsActive,IsNotActiveReason,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy) values(@Id,@CreationDate,@ServerId,@Code,@TypeId,@Name,@Address,@ProvinceId,@DistrictId,@PhoneNumber,@Email,@TaxOffice,@TaxNumber,@Administration,@AuthorizedName,@AuthorizedPhoneNumber,@AuthorizedEmail,@Explanation,@DatabaseTypeId,@IsSharedDatabase,@ConnectionString,@IsOnlyTenant,@IsActive,@IsNotActiveReason,@CreatedDate,@CreatedBy,@ModifiedDate,@ModifiedBy)";
                await _repo.SaveData(query, new { Id = tenants.Id, CreationDate = tenants.CreationDate, ServerId = tenants.ServerId, Code = tenants.Code, TypeId = tenants.TypeId, Name = tenants.Name, Address = tenants.Address, ProvinceId = tenants.ProvinceId, DistrictId = tenants.DistrictId, PhoneNumber = tenants.PhoneNumber, Email = tenants.Email, TaxOffice = tenants.TaxOffice, TaxNumber = tenants.TaxNumber, Administration = tenants.Administration, AuthorizedName = tenants.AuthorizedName, AuthorizedPhoneNumber = tenants.AuthorizedPhoneNumber, AuthorizedEmail = tenants.AuthorizedEmail, Explanation = tenants.Explanation, DatabaseTypeId = tenants.DatabaseTypeId, IsSharedDatabase = tenants.IsSharedDatabase, ConnectionString = tenants.ConnectionString, IsOnlyTenant = tenants.IsOnlyTenant, IsActive = tenants.IsActive, IsNotActiveReason = tenants.IsNotActiveReason, CreatedDate = tenants.CreatedDate, CreatedBy = tenants.CreatedBy, ModifiedDate = tenants.ModifiedDate, ModifiedBy = tenants.ModifiedBy });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateTenants(Tenants tenants)
        {
            try
            {
                string query = "update dbo.Tenants set  CreationDate = @CreationDate, ServerId = @ServerId, Code = @Code, TypeId = @TypeId, Name = @Name, Address = @Address, ProvinceId = @ProvinceId, DistrictId = @DistrictId, PhoneNumber = @PhoneNumber, Email = @Email, TaxOffice = @TaxOffice, TaxNumber = @TaxNumber, Administration = @Administration, AuthorizedName = @AuthorizedName, AuthorizedPhoneNumber = @AuthorizedPhoneNumber, AuthorizedEmail = @AuthorizedEmail, Explanation = @Explanation, DatabaseTypeId = @DatabaseTypeId, IsSharedDatabase = @IsSharedDatabase, ConnectionString = @ConnectionString, IsOnlyTenant = @IsOnlyTenant, IsActive = @IsActive, IsNotActiveReason = @IsNotActiveReason, CreatedDate = @CreatedDate, CreatedBy = @CreatedBy, ModifiedDate = @ModifiedDate, ModifiedBy = @ModifiedBy where Id=@Id";
                await _repo.SaveData(query, tenants);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteTenants(int id)
        {
            try
            {
                string query = "delete from dbo.Tenants where id = @Id";
                await _repo.SaveData(query, new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<IEnumerable<Tenants>> GetTenants()
        {
            string query = "select * from dbo.Tenants";
            var tenants = await _repo.GetData<Tenants, dynamic>(query, new { });
            return tenants;
        }
        public async Task<Tenants> GetTenantsById(int id)
        {
            string query = "select * from dbo.Tenants where Id=@Id";
            IEnumerable<Tenants> tenants = await _repo.GetData<Tenants, dynamic>(query, new { Id = id });
            return tenants.FirstOrDefault();
        }


    }
}