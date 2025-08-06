using My_new_API.DTO_s;
using My_new_API.Models;

namespace My_new_API.Repositories
{
    public class InMemoryRepository : IRegionRepository
    {
        Task<Region> IRegionRepository.deleteRegionasync(Guid regionid)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<Region>> IRegionRepository.GetAllAsync()
        {
            return new List<Region>
            {
                new Region(){
                    Name = "Data1",
                    Code = "DT1",
                    Id = Guid.NewGuid(),
                    ImageUrl = "qwdbqdb"
                }
            };
        }

        Task<Region> IRegionRepository.GetRegionById(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<Region> IRegionRepository.insertRegionasync(RegionDTO regiondto)
        {
            throw new NotImplementedException();
        }

        Task<Region> IRegionRepository.updateRegionasync(RegionDTO regiondto, Guid regionid)
        {
            throw new NotImplementedException();
        }
    }
}
