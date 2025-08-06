using My_new_API.DTO_s;
using My_new_API.Models;

namespace My_new_API.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
        Task<Region> GetRegionById(Guid id);
        Task<Region> insertRegionasync(RegionDTO regiondto);
        Task<Region> updateRegionasync(RegionDTO regiondto,Guid regionid);
        Task<Region> deleteRegionasync(Guid regionid);
    }
}
