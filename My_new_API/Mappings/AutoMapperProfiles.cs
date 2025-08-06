using AutoMapper;
using My_new_API.DTO_s;
using My_new_API.Models;

namespace My_new_API.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles() {
            CreateMap<mappDTO1, mappDTO2>()
                .ForMember(x => x.Id2, opt => opt.MapFrom(x => x.Id1)) // Used when parameter names are different
                .ReverseMap();    //mapping can happen in opposite.
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<Walk, WalksDTO>().ReverseMap();
            CreateMap<Difficulty, DifficultyDTO>().ReverseMap();
        }

        public class mappDTO1
        {
            public string Id1 { get; set; }
        }
        public class mappDTO2
        {
            public string Id2 { get; set; }
        }
    }
}
