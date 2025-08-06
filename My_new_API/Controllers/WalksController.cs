using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using My_new_API.CustomActionFilter;
using My_new_API.DTO_s;
using My_new_API.Models;
using My_new_API.Repositories.Interfaces;

namespace My_new_API.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class WalksController : Controller
    {
        public readonly IMapper _Mapper;
        public readonly IWalksRepository _walksRepository;
        public WalksController(IMapper Mapper, IWalksRepository _walksRepository)
        {
            this._Mapper = Mapper;
            this._walksRepository = _walksRepository;
        }
        [HttpPost]
        [CustomModelValidation]
        public async Task<IActionResult> CreateWalks([FromBody]WalksDTO walk)
        {
            await _walksRepository.CreateAsync(walk);
            return Ok(walk);
        }

        [HttpGet("GetWalks")]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy, [FromQuery] bool? isAscending, [FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var walks = await _walksRepository.GetAll(filterOn,filterQuery,sortBy,isAscending,pageNumber,pageSize);
            return Ok(_Mapper.Map<List<WalksDTO>>(walks));
        }

        [HttpGet]
        [Route("GetByID/{Id}")]
        public async Task<IActionResult> GetById([FromRoute]Guid Id)
        {
            var Walk = await _walksRepository.GetById(Id);
            return Ok(_Mapper.Map<WalksDTO>(Walk));
        }

        [HttpPut]
        [Route("UpdateWalk/{Id}")]
        [CustomModelValidation]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid Id, [FromBody] WalksDTO walksDTO)
        {
            var walk = await _walksRepository.UpdateById(Id, walksDTO);
            return Ok($"{walk.Name} Updated");
        }

        [HttpDelete]
        [Route("DeleteWalk/{Id}")]
        public async Task<IActionResult> DeleteWalk([FromRoute] Guid Id)
        {
            var walk = await _walksRepository.DeleteById(Id);
            return Ok($"{walk.Name} Deleted");
        }

    }
}
