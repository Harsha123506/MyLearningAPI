using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_new_API.Data;
using My_new_API.DTO_s;
using My_new_API.Models;

namespace My_new_API.Repositories
{
    public class SqlRegionRepository:IRegionRepository
    {
        public readonly DataContext _DataContext;
        public SqlRegionRepository(DataContext dataContext)
        {
            _DataContext = dataContext;
        }
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _DataContext.regions.ToListAsync();
        }

        public async Task<Region> GetRegionById(Guid Id)
        {
            return await _DataContext.regions.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<Region> insertRegionasync(RegionDTO regiondto)
        {
            _DataContext.regions.Add(new Region()
            {
                Name = regiondto.Name,
                ImageUrl = regiondto.ImageUrl,
                Code = regiondto.code,
                Id = Guid.NewGuid()
            });
            await _DataContext.SaveChangesAsync();
            return await _DataContext.regions.FirstOrDefaultAsync(x=>x.Name == regiondto.Name);
        }

        public async Task<Region> updateRegionasync(RegionDTO regiondto,Guid regionId)
        {
            var region = await _DataContext.regions.FirstOrDefaultAsync(x=> x.Id == regionId);
            region.Name = regiondto.Name;
            region.ImageUrl = regiondto.ImageUrl;  
            region.Code = regiondto.code;
            await _DataContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> deleteRegionasync(Guid regionId)
        {
            var region = _DataContext.regions.FirstOrDefault(x=> x.Id == regionId);
            _DataContext.regions.Remove(region);
            await _DataContext.SaveChangesAsync();
            return region;
        }
    }
}
