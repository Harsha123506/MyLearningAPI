using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_new_API.Data;
using My_new_API.DTO_s;
using My_new_API.Models;
using My_new_API.Repositories;

namespace My_new_API.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        public readonly DataContext _DataContext;
        public readonly IRegionRepository _regionRepository;
        public readonly IMapper _mapper;
        public RegionsController(DataContext context,IRegionRepository regionRepository,IMapper mapper) {
            this._DataContext = context;
            this._regionRepository = regionRepository;
            this._mapper = mapper;
        }

        [Authorize(Roles = "Reader")]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Region> wk = new List<Region>
            {
                new Region
                {
                    Id=Guid.NewGuid(),
                    Name = "Yelhanka",
                    Code = "YLH",
                    ImageUrl = "https://meta.wikimedia.org/wiki/Wikimedia_regions#/media/File:Wikimedia_regions_-_Sub-Saharan_Africa.svg"

                },
                new Region
                {
                    Id=Guid.NewGuid(),
                    Name = "Maldives",
                    Code = "MLD",
                    ImageUrl = "https://meta.wikimedia.org/wiki/Wikimedia_regions#/media/File:Wikimedia_regions_-_South_Asia.svg"
                }
            };
            return Ok(wk);
        }

        [HttpGet("getregions")]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions =  await _regionRepository.GetAllAsync();
            var regionDTOs = new List<RegionDTO>();
            regionDTOs = _mapper.Map<List<RegionDTO>>(regions);
            return Ok(regionDTOs);
        }

        [HttpGet("getregions/{id}")]
        public async Task<IActionResult> GetRegionById(Guid id)
        {
            var region  = _regionRepository.GetRegionById(id);
            return Ok(region);
        }

        [Authorize(Roles = "Writer")]
        [HttpPost("insertregions")]
        public async Task<IActionResult> Insertregions([FromBody] RegionDTO regiondto)
        {
            var region  = await _regionRepository.insertRegionasync(regiondto);
            if (region != null) {
                return CreatedAtAction(nameof(Insertregions), new { region.Id }, regiondto);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] RegionDTO regiondto)
        {
            var region = await _regionRepository.updateRegionasync(regiondto, id);
            if (region != null)
            {
                return Ok(_mapper.Map<RegionDTO>(region));
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var region = await _regionRepository.deleteRegionasync(id);
            if (region != null)
            {
                return Ok($"{region.Name} deleted");
            }
            return NotFound("Couldn't find the record");
        }
     }

}