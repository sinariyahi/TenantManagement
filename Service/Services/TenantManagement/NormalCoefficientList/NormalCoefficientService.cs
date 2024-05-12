using Contracts.Dto.ExceptionLogsList;
using Contracts.Dto.NormalCoefficientList;
using Contracts.Interface.Shared;
using Contracts.Interface.TenantManagement.ExceptionLogsList;
using Contracts.Interface.TenantManagement.NormalCoefficientList;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.TenantManagement.NormalCoefficientList
{
    public class NormalCoefficientService : INormalCoefficientService, IBaseService
    {
        private readonly IGenericRepository _repo;
        public NormalCoefficientService(IGenericRepository repo)
        {
            _repo = repo;
        }

        

        public async Task<bool> AddNormalCoefficient(NormalCoefficient normalCoefficient)
        {
            try
            {
                string query = "insert into dbo.NormalCoefficient(Id,emsanorn1,emsanorn2,emsanorn3,emsanorn4,emsanorn5,emsanorn6,emsanorn7,emsantut1,emsantut2,emsantut3,emsantut4,emsantut5,emsantut6,emsantut7,gelverorn1,gelverorn2,gelverorn3,gelverorn4,gelvertut1,gelvertut2,gelvertut3,gelvertut4,sakatlik1,sakatlik2,sakatlik3,raporkes1,raporkes2,raporkes3,raporkes4,maaskat,tabanaykat,tabanaygos,kidemgos,yanodemekat,aileyargos,cocukyargos,makam,eydm) values(@Id,@emsanorn1,@emsanorn2,@emsanorn3,@emsanorn4,@emsanorn5,@emsanorn6,@emsanorn7,@emsantut1,@emsantut2,@emsantut3,@emsantut4,@emsantut5,@emsantut6,@emsantut7,@gelverorn1,@gelverorn2,@gelverorn3,@gelverorn4,@gelvertut1,@gelvertut2,@gelvertut3,@gelvertut4,@sakatlik1,@sakatlik2,@sakatlik3,@raporkes1,@raporkes2,@raporkes3,@raporkes4,@maaskat,@tabanaykat,@tabanaygos,@kidemgos,@yanodemekat,@aileyargos,@cocukyargos,@makam,@eydm)";
                await _repo.SaveData(query, new { Id = normalCoefficient.Id, emsanorn1 = normalCoefficient.emsanorn1, emsanorn2 = normalCoefficient.emsanorn2, emsanorn3 = normalCoefficient.emsanorn3, emsanorn4 = normalCoefficient.emsanorn4, emsanorn5 = normalCoefficient.emsanorn5, emsanorn6 = normalCoefficient.emsanorn6, emsanorn7 = normalCoefficient.emsanorn7, emsantut1 = normalCoefficient.emsantut1, emsantut2 = normalCoefficient.emsantut2, emsantut3 = normalCoefficient.emsantut3, emsantut4 = normalCoefficient.emsantut4, emsantut5 = normalCoefficient.emsantut5, emsantut6 = normalCoefficient.emsantut6, emsantut7 = normalCoefficient.emsantut7, gelverorn1 = normalCoefficient.gelverorn1, gelverorn2 = normalCoefficient.gelverorn2, gelverorn3 = normalCoefficient.gelverorn3, gelverorn4 = normalCoefficient.gelverorn4, gelvertut1 = normalCoefficient.gelvertut1, gelvertut2 = normalCoefficient.gelvertut2, gelvertut3 = normalCoefficient.gelvertut3, gelvertut4 = normalCoefficient.gelvertut4, sakatlik1 = normalCoefficient.sakatlik1, sakatlik2 = normalCoefficient.sakatlik2, sakatlik3 = normalCoefficient.sakatlik3, raporkes1 = normalCoefficient.raporkes1, raporkes2 = normalCoefficient.raporkes2, raporkes3 = normalCoefficient.raporkes3, raporkes4 = normalCoefficient.raporkes4, maaskat = normalCoefficient.maaskat, tabanaykat = normalCoefficient.tabanaykat, tabanaygos = normalCoefficient.tabanaygos, kidemgos = normalCoefficient.kidemgos, yanodemekat = normalCoefficient.yanodemekat, aileyargos = normalCoefficient.aileyargos, cocukyargos = normalCoefficient.cocukyargos, makam = normalCoefficient.makam, eydm = normalCoefficient.eydm });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateNormalCoefficient(NormalCoefficient normalCoefficient)
        {
            try
            {
                string query = "update dbo.NormalCoefficient set  emsanorn1 = @emsanorn1, emsanorn2 = @emsanorn2, emsanorn3 = @emsanorn3, emsanorn4 = @emsanorn4, emsanorn5 = @emsanorn5, emsanorn6 = @emsanorn6, emsanorn7 = @emsanorn7, emsantut1 = @emsantut1, emsantut2 = @emsantut2, emsantut3 = @emsantut3, emsantut4 = @emsantut4, emsantut5 = @emsantut5, emsantut6 = @emsantut6, emsantut7 = @emsantut7, gelverorn1 = @gelverorn1, gelverorn2 = @gelverorn2, gelverorn3 = @gelverorn3, gelverorn4 = @gelverorn4, gelvertut1 = @gelvertut1, gelvertut2 = @gelvertut2, gelvertut3 = @gelvertut3, gelvertut4 = @gelvertut4, sakatlik1 = @sakatlik1, sakatlik2 = @sakatlik2, sakatlik3 = @sakatlik3, raporkes1 = @raporkes1, raporkes2 = @raporkes2, raporkes3 = @raporkes3, raporkes4 = @raporkes4, maaskat = @maaskat, tabanaykat = @tabanaykat, tabanaygos = @tabanaygos, kidemgos = @kidemgos, yanodemekat = @yanodemekat, aileyargos = @aileyargos, cocukyargos = @cocukyargos, makam = @makam, eydm = @eydm where Id=@Id";
                await _repo.SaveData(query, normalCoefficient);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteNormalCoefficient(int id)
        {
            try
            {
                string query = "delete from dbo.NormalCoefficient where id = @Id";
                await _repo.SaveData(query, new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<NormalCoefficient>> GetNormalCoefficient()
        {
            string query = "select * from dbo.NormalCoefficient";
            var normalCoefficient = await _repo.GetData<NormalCoefficient, dynamic>(query, new { });
            return normalCoefficient;
        }

        public async Task<NormalCoefficient> GetNormalCoefficientById(int id)
        {
            string query = "select * from dbo.NormalCoefficient where Id=@Id";
            IEnumerable<NormalCoefficient> normalCoefficient = await _repo.GetData<NormalCoefficient, dynamic>(query, new { Id = id });
            return normalCoefficient.FirstOrDefault();
        }
    }
}
