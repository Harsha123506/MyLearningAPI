using AutoMapper;
using Microsoft.EntityFrameworkCore;
using My_new_API.Data;
using My_new_API.DTO_s;
using My_new_API.Models;
using My_new_API.Repositories.Interfaces;

namespace My_new_API.Repositories
{
    public class SQLWalksRepository:IWalksRepository
    {
        public readonly DataContext _Context;
        public readonly IMapper _mapper;
        public SQLWalksRepository(DataContext dataContext,IMapper mapper) {
            _Context = dataContext;
            _mapper = mapper;
        }
        async Task<WalksDTO> IWalksRepository.CreateAsync(WalksDTO walks)
        {
            await _Context.walks.AddAsync(_mapper.Map<Walk>(walks));
            await _Context.SaveChangesAsync();
            return walks;
        }

        async Task<Walk> IWalksRepository.DeleteById(Guid Id)
        {
            var walktoremove = _Context.walks.FirstOrDefault(x => x.Id == Id);
            _Context.walks.Remove(walktoremove);
            await _Context.SaveChangesAsync();
            return walktoremove;
        }

        async Task<List<Walk>> IWalksRepository.GetAll(string? filterOn, string? filterQuery, string? sortBy = null, bool? isAscending = null, int pageNumber = 1, int pageSize = 25)
        {
            var Walks = _Context.walks.Include("Difficulty").Include("Region").AsQueryable();
            if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrEmpty(filterQuery))
            {
                if (filterOn.ToLower() == "name")
                {
                    Walks = Walks.Where(x => x.Name.ToLower().Contains(filterQuery.ToLower()));  //filtering as per the query parameters 
                }
                else if (filterOn.ToLower() == "description")
                {
                    Walks = Walks.Where(x => x.Description.ToLower().Contains(filterQuery.ToLower()));
                }
            }
            if (!string.IsNullOrWhiteSpace(sortBy))  //sorting 
            {
                if (sortBy.ToLower() == "name")
                {
                    Walks = isAscending == true ? Walks.OrderBy(x => x.Name) : Walks.OrderByDescending(x => x.Name);
                }
                else if (sortBy.ToLower() == "difficulty")
                {
                    Walks = isAscending == true ? Walks.OrderBy(x => x.Difficulty.Name) : Walks.OrderByDescending(x => x.Difficulty.Name);
                }
            }
            var skipResults = (pageNumber - 1) * pageSize;     //pagination
            Walks = Walks.Skip(skipResults).Take(pageSize);

            return await Walks.ToListAsync();
        }

        async Task<Walk> IWalksRepository.GetById(Guid Id)
        {
            return await _Context.walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == Id);
        }

        async Task<Walk> IWalksRepository.UpdateById(Guid Id,WalksDTO walkToUpdate)
        {
            var walk = await _Context.walks.FirstOrDefaultAsync(x => x.Id == Id);
            walk.Name = walkToUpdate.Name;
            walk.Description = walkToUpdate.Description;
            walk.WalkImageUrl = walkToUpdate.WalkImageUrl;
            walk.LengthInKm = walkToUpdate.LengthInKm;
            return walk;
        }
    }
}
