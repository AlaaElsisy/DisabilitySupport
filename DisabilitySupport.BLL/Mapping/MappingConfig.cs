using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DisabilitySupport.BLL.DTOs;
using DisabilitySupport.DAL.Models;

namespace DisabilitySupport.BLL.Mapping
{
    public class MappingConfig:Profile
    {
        public MappingConfig() { 
        
            CreateMap<HelperRequest,HelperRequestDto>().ReverseMap();
            CreateMap<HelperService,HelperServiceDto>().ReverseMap();

            CreateMap<DisabledRequest, DisabledRequestDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<DisabilitySupport.DAL.Models.Enumerations.RequestStatus>(src.Status)));
        }
    }
}
