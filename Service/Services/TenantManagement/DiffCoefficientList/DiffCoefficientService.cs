using Contracts.Dto.AuditTrailsList;
using Contracts.Dto.DiffCoefficientList;
using Contracts.Interface.Shared;
using Contracts.Interface.TenantManagement.AuditTrailsList;
using Contracts.Interface.TenantManagement.DiffCoefficientList;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.TenantManagement.DiffCoefficientList
{
    public  class DiffCoefficientService : IDiffCoefficientService , IBaseService
    {
        private readonly IGenericRepository _repo;
        public DiffCoefficientService(IGenericRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> AddDiffCoefficient(DiffCoefficient diffCoefficient)
        {
            try
            {
                 string query = "insert into dbo.DiffCoefficient(Id,maaskat1,tabanaykat1,tabanaygos1,kidemgos1,yanodemekat1,aileyargos1,cocukyargos1,makam1,eydm1,maaskat2,tabanaykat2,tabanaygos2,kidemgos2,yanodemekat2,aileyargos2,cocukyargos2,makam2,eydm2) values(@Id,@maaskat1,@tabanaykat1,@tabanaygos1,@kidemgos1,@yanodemekat1,@aileyargos1,@cocukyargos1,@makam1,@eydm1,@maaskat2,@tabanaykat2,@tabanaygos2,@kidemgos2,@yanodemekat2,@aileyargos2,@cocukyargos2,@makam2,@eydm2)";
                await _repo.SaveData(query, new { Id = diffCoefficient.Id, maaskat1 = diffCoefficient.maaskat1, tabanaykat1 = diffCoefficient.tabanaykat1, tabanaygos1 = diffCoefficient.tabanaygos1, kidemgos1 = diffCoefficient.kidemgos1, yanodemekat1 = diffCoefficient.yanodemekat1, aileyargos1 = diffCoefficient.aileyargos1, cocukyargos1 = diffCoefficient.cocukyargos1, makam1 = diffCoefficient.makam1, eydm1 = diffCoefficient.eydm1, maaskat2 = diffCoefficient.maaskat2, tabanaykat2 = diffCoefficient.tabanaykat2, tabanaygos2 = diffCoefficient.tabanaygos2, kidemgos2 = diffCoefficient.kidemgos2, yanodemekat2 = diffCoefficient.yanodemekat2, aileyargos2 = diffCoefficient.aileyargos2, cocukyargos2 = diffCoefficient.cocukyargos2, eydm2 = diffCoefficient.eydm2 });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateDiffCoefficient(DiffCoefficient diffCoefficient)
        {
            try
            {
                string query = "update dbo.DiffCoefficient set  maaskat1 = @maaskat1, tabanaykat1 = @tabanaykat1, tabanaygos1 = @tabanaygos1, kidemgos1 = @kidemgos1, yanodemekat1 = @yanodemekat1, aileyargos1 = @aileyargos1, cocukyargos1 = @cocukyargos1, makam1 = @makam1, eydm1 = @eydm1, maaskat2 = @maaskat2, tabanaykat2 = @tabanaykat2, tabanaygos2 = @tabanaygos2, kidemgos2 = @kidemgos2, yanodemekat2 = @yanodemekat2, aileyargos2 = @aileyargos2, cocukyargos2 = @cocukyargos2, eydm2 = @eydm2  where Id=@Id";
                await _repo.SaveData(query, diffCoefficient);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteDiffCoefficient(int id)
        {
            try
            {
                string query = "delete from dbo.DiffCoefficient where id = @Id";
                await _repo.SaveData(query, new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<DiffCoefficient>> GetDiffCoefficient()
        {
            string query = "select * from dbo.DiffCoefficient";
            var diffCoefficient = await _repo.GetData<DiffCoefficient, dynamic>(query, new { });
            return diffCoefficient;
        }

        public async Task<DiffCoefficient> GetDiffCoefficientById(int id)
        {
            string query = "select * from dbo.DiffCoefficient where Id=@Id";
            IEnumerable<DiffCoefficient> diffCoefficient = await _repo.GetData<DiffCoefficient, dynamic>(query, new { Id = id });
            return diffCoefficient.FirstOrDefault();
        }
    }
}

