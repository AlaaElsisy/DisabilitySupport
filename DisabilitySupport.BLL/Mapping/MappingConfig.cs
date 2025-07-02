using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DisabilitySupport.BLL.DTOs;
using DisabilitySupport.BLL.DTOs.helper.Request;
using DisabilitySupport.BLL.DTOs.helper.service;
using DisabilitySupport.BLL.DTOs.ServiceCategory;
using DisabilitySupport.DAL.Models;
using DisabilitySupport.DAL.Models.Enumerations;

namespace DisabilitySupport.BLL.Mapping
{
    public class MappingConfig:Profile
    {
        public MappingConfig() {
            #region helper
            CreateMap<HelperRequest,HelperRequestDto>().ReverseMap();
            CreateMap<HelperService,HelperServiceDto>().ReverseMap();
            CreateMap<HelperService, UpdateHelperServiceDto>().ReverseMap();
 
            CreateMap<UpdateHelperRequestDto, HelperRequest>()
                 .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<HelperRequestStatus>(src.Status, true)))
                 .ReverseMap()
                 .ForMember(dest => dest.Status,  opt => opt.MapFrom(src => src.Status.ToString()));
            #endregion


            #region disabled

            CreateMap<DisabledOffer, DisabledOfferDto>()
             .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
             .ReverseMap()
             .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<DisabledOfferStatus>(src.Status)));

 

            CreateMap<DisabledRequest, DisabledRequestDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<DisabilitySupport.DAL.Models.Enumerations.RequestStatus>(src.Status)));
            #endregion
            CreateMap<HelperService, HelperServiceDetailsDto>()
                .ForMember(dest => dest.HelperId, opt => opt.MapFrom(src => src.HelperId))
                .ForMember(dest => dest.ServiceCategoryId, opt => opt.MapFrom(src => src.ServiceCategoryId))
                .ForMember(dest => dest.HelperName, opt => opt.MapFrom(src => src.Helper != null && src.Helper.User != null ? src.Helper.User.FullName : null))
                .ForMember(dest => dest.HelperImage, opt => opt.MapFrom(src => src.Helper != null && src.Helper.User != null ? src.Helper.User.ProfileImage : null))
                .ForMember(dest => dest.ServiceCategoryName, opt => opt.MapFrom(src => src.ServiceCategory != null ? src.ServiceCategory.Name : null));


            #region ServiceCategory

            CreateMap<ServiceCategory, ServiceCategoryDto>().ReverseMap();
            CreateMap<ServiceCategory, ServiceCategoryDiscDto>().ReverseMap();

            #endregion

            CreateMap<Disabled, DisabledDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.FullName))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.User.Address))
            .ForMember(dest => dest.Zone, opt => opt.MapFrom(src => src.User.Zone))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.User.DateOfBirth))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.User.Gender))
            .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.User.ProfileImage));


        }
    }
}
