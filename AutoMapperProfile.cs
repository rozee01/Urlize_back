using AutoMapper;
using Urlize_back.Dtos;
using Urlize_back.Models;

namespace Urlize_back
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Business, BusinessCreateDto>();
            CreateMap<BusinessCreateDto,Business>();


        }
    }
}
