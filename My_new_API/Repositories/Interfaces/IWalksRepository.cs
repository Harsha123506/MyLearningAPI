using My_new_API.DTO_s;
using My_new_API.Models;

namespace My_new_API.Repositories.Interfaces
{
    public interface IWalksRepository
    {
        public Task<WalksDTO> CreateAsync(WalksDTO walks);
        public Task<List<Walk>> GetAll(string? filterOn=null,string? filterQuery=null,string? sortBy = null,bool? isAscending = null, int pageNumber = 1, int pageSize = 25);
        public Task<Walk> GetById(Guid Id);
        public Task<Walk> UpdateById(Guid Id,WalksDTO walkToUpdate);
        public Task<Walk> DeleteById(Guid Id);
    }
}
