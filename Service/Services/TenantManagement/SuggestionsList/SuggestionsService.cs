using Contracts.Dto.ServersList;
using Contracts.Dto.SuggestionsList;
using Contracts.Interface.Shared;
using Contracts.Interface.TenantManagement.ServersList;
using Contracts.Interface.TenantManagement.SuggestionsList;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.TenantManagement.SuggestionsList
{
    public class SuggestionsService : ISuggestionsService, IBaseService
    {
        private readonly IGenericRepository _repo;
        public SuggestionsService(IGenericRepository repo)
        {
            _repo = repo;
        }
        
        public async Task<bool> AddSuggestions(Suggestions suggestions)
        {
            try
            {
                string query = "insert into dbo.Suggestions(Id,ProjectId,TenantId,Message,CreationDate,IsSolved,Explanation,SolvedBy) values(@Id,@ProjectId,@TenantId,@Message,@CreationDate,@IsSolved,@Explanation,@SolvedBy)";
                await _repo.SaveData(query, new { Id = suggestions.Id, ProjectId = suggestions.ProjectId, TenantId = suggestions.TenantId, Message = suggestions.Message, CreationDate = suggestions.CreationDate, IsSolved = suggestions.IsSolved, Explanation = suggestions.Explanation, SolvedBy = suggestions.SolvedBy});
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateSuggestions(Suggestions suggestions)
        {
            try
            {
                string query = "update dbo.Suggestions set  ProjectId = @ProjectId, TenantId = @TenantId, Message = @Message, CreationDate = @CreationDate, IsSolved = @IsSolved, Explanation = @Explanation, SolvedBy = @SolvedBy where Id=@Id";
                await _repo.SaveData(query, suggestions);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteSuggestions(int id)
        {
            try
            {
                string query = "delete from dbo.Suggestions where id = @Id";
                await _repo.SaveData(query, new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Suggestions>> GetSuggestions()
        {
            string query = "select * from dbo.Suggestions";
            var suggestions = await _repo.GetData<Suggestions, dynamic>(query, new { });
            return suggestions;
        }

        public async Task<Suggestions> GetSuggestionsById(int id)
        {
            string query = "select * from dbo.Suggestions where Id=@Id";
            IEnumerable<Suggestions> suggestions = await _repo.GetData<Suggestions, dynamic>(query, new { Id = id });
            return suggestions.FirstOrDefault();
        }


    }
}