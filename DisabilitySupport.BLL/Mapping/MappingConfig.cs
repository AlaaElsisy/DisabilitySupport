using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DisabilitySupport.BLL.DTOs;
using DisabilitySupport.BLL.DTOs.helper.Request;
using DisabilitySupport.BLL.DTOs.helper.service;
using DisabilitySupport.DAL.Models;
using DisabilitySupport.DAL.Models.Enumerations;

namespace DisabilitySupport.BLL.Mapping
{
    public class MappingConfig:Profile
    {
        public MappingConfig() { 
        
            CreateMap<HelperRequest,HelperRequestDto>().ReverseMap();
            CreateMap<HelperService,HelperServiceDto>().ReverseMap();
            CreateMap<HelperService, UpdateHelperServiceDto>().ReverseMap();
            CreateMap<UpdateHelperRequestDto, HelperRequest>()
                 .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<HelperRequestStatus>(src.Status, true)))
                 .ReverseMap()
                 .ForMember(dest => dest.Status,  opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<DisabledRequest, DisabledRequestDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<DisabilitySupport.DAL.Models.Enumerations.RequestStatus>(src.Status)));
        }
    }
}
