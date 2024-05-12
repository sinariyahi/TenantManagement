using Contracts.Dto.ProvincesList;
using Contracts.Dto.PublicHolidaysList;
using Contracts.Interface.Shared;
using Contracts.Interface.TenantManagement.ProvincesList;
using Contracts.Interface.TenantManagement.PublicHolidaysList;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.TenantManagement.PublicHolidaysList
{
    public class PublicHolidaysService : IPublicHolidaysService, IBaseService
    {
        private readonly IGenericRepository _repo;
        public PublicHolidaysService(IGenericRepository repo)
        {
            _repo = repo;
        }
        

        public async Task<bool> AddPublicHolidays(PublicHolidays publicHolidays)
        {
            try
            {
                string query = "insert into dbo.PublicHolidays(Id,Tarih,Explanation,Type) values(@Id,@Tarih,@Explanation,@Type)";
                await _repo.SaveData(query, new { Id = publicHolidays.Id, Tarih = publicHolidays.Tarih, Explanation = publicHolidays.Explanation, Type = publicHolidays.Type});
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdatePublicHolidays(PublicHolidays publicHolidays)
        {
            try
            {
                string query = "update dbo.PublicHolidays set  Tarih = @Tarih, Explanation = @Explanation, Type = @Type where Id=@Id";
                await _repo.SaveData(query, publicHolidays);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeletePublicHolidays(int id)
        {
            try
            {
                string query = "delete from dbo.PublicHolidays where id = @Id";
                await _repo.SaveData(query, new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<PublicHolidays>> GetPublicHolidays()
        {
            string query = "select * from dbo.PublicHolidays";
            var publicHolidays = await _repo.GetData<PublicHolidays, dynamic>(query, new { });
            return publicHolidays;
        }

        public async Task<PublicHolidays> GetPublicHolidaysById(int id)
        {
            string query = "select * from dbo.Provinces where Id=@Id";
            IEnumerable<PublicHolidays> publicHolidays = await _repo.GetData<PublicHolidays, dynamic>(query, new { Id = id });
            return publicHolidays.FirstOrDefault();
        }
    }
}