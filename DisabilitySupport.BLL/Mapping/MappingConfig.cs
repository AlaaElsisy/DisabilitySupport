using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DisabilitySupport.BLL.DTOs.Disabled;
using DisabilitySupport.BLL.DTOs.helper;
using DisabilitySupport.BLL.DTOs.helper.Request;
using DisabilitySupport.BLL.DTOs.helper.service;
using DisabilitySupport.BLL.DTOs.payment;
using DisabilitySupport.BLL.DTOs.ServiceCategory;
using DisabilitySupport.DAL.Models;
using DisabilitySupport.DAL.Models.Enumerations;

namespace DisabilitySupport.BLL.Mapping
{
    public class MappingConfig:Profile
    {
        public MappingConfig() {
            #region helper


            CreateMap<HelperRequest, HelperRequestDto>()
                .ForMember(dest => dest.HelperName,
                    opt => opt.MapFrom(src => src.Helper != null && src.Helper.User != null ? src.Helper.User.FullName : null))
                .ForMember(dest => dest.DisabledName,
                    opt => opt.MapFrom(src => src.DisabledOffer != null && src.DisabledOffer.Disabled != null && src.DisabledOffer.Disabled.User != null
                        ? src.DisabledOffer.Disabled.User.FullName : null))
                .ForMember(dest => dest.Service,
                    opt => opt.MapFrom(src => src.DisabledOffer != null ? src.DisabledOffer.Description : null))
                .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(src => Enum.Parse<HelperRequestStatus>(src.Status, true))); 


            CreateMap<HelperRequest,HelperRequestDetailsDto>()
            .ForMember(dest => dest.HelperName, opt => opt.MapFrom(src => src.Helper != null && src.Helper.User != null ? src.Helper.User.FullName : null))
            .ForMember(dest => dest.HelperImage, opt => opt.MapFrom(src => src.Helper != null && src.Helper.User != null ? src.Helper.User.ProfileImage : null))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Helper.UserId))
            .ForMember(dest => dest.DisabledName,
                    opt => opt.MapFrom(src => src.DisabledOffer != null && src.DisabledOffer.Disabled != null && src.DisabledOffer.Disabled.User != null
                        ? src.DisabledOffer.Disabled.User.FullName : null))
                .ForMember(dest => dest.Service,
                    opt => opt.MapFrom(src => src.DisabledOffer != null ? src.DisabledOffer.Description : null))
            .ReverseMap();


            CreateMap<HelperService,HelperServiceDto>().ReverseMap();
            CreateMap<HelperService, UpdateHelperServiceDto>().ReverseMap();
 
            CreateMap<UpdateHelperRequestDto, HelperRequest>()
                 .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<HelperRequestStatus>(src.Status, true)))
                 .ReverseMap()
                 .ForMember(dest => dest.Status,  opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<HelperRequest, HelperRequestCardDto>()
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
               .ForMember(dest => dest.OfferDescription, opt => opt.MapFrom(src => src.DisabledOffer.Description))
               .ForMember(dest => dest.StartServiceTime, opt => opt.MapFrom(src => src.DisabledOffer.StartServiceTime))
               .ForMember(dest => dest.EndServiceTime, opt => opt.MapFrom(src => src.DisabledOffer.EndServiceTime))
               .ForMember(dest => dest.Budget, opt => opt.MapFrom(src => src.DisabledOffer.Budget))
               .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.DisabledOffer.ServiceCategory.Name))
               .ForMember(dest => dest.PosterName, opt => opt.MapFrom(src => src.DisabledOffer.Disabled.User.FullName))
               .ForMember(dest => dest.PosterImage, opt => opt.MapFrom(src => src.DisabledOffer.Disabled.User.ProfileImage))
               .ForMember(dest => dest.PosterUserId, opt => opt.MapFrom(src => src.DisabledOffer.Disabled.User.Id));
              
            CreateMap<HelperService, HelperServiceDetailsDto>()
               .ForMember(dest => dest.HelperId, opt => opt.MapFrom(src => src.HelperId))
               .ForMember(dest => dest.ServiceCategoryId, opt => opt.MapFrom(src => src.ServiceCategoryId))
               .ForMember(dest => dest.HelperName, opt => opt.MapFrom(src => src.Helper != null && src.Helper.User != null ? src.Helper.User.FullName : null))
               .ForMember(dest => dest.HelperImage, opt => opt.MapFrom(src => src.Helper != null && src.Helper.User != null ? src.Helper.User.ProfileImage : null))
               .ForMember(dest => dest.ServiceCategoryName, opt => opt.MapFrom(src => src.ServiceCategory != null ? src.ServiceCategory.Name : null))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Helper.UserId ))
               .ReverseMap();


            #endregion



            #region disabled

            CreateMap<DisabledOffer, DisabledOfferDto>()
             .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
             .ReverseMap()
             .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<DisabledOfferStatus>(src.Status)));

            CreateMap<DisabledRequest, DisabledRequestDetailsDto>()
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
               .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src =>
                   src.HelperService != null ? src.HelperService.ServiceCategoryId : (int?)null))
               .ForMember(dest => dest.HelperName, opt => opt.MapFrom(src =>
                   src.HelperService != null && src.HelperService.Helper != null && src.HelperService.Helper.User != null
                       ? src.HelperService.Helper.User.FullName : null))
               .ForMember(dest => dest.HelperImage, opt => opt.MapFrom(src =>
                   src.HelperService != null && src.HelperService.Helper != null && src.HelperService.Helper.User != null
                       ? src.HelperService.Helper.User.ProfileImage : null))
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Disabled.UserId))
               .ForMember(dest => dest.HelperUserId, opt => opt.MapFrom(src =>
                 src.HelperService != null && src.HelperService.Helper != null
                  ? src.HelperService.Helper.UserId : null))
               .ReverseMap()
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src =>
                   Enum.Parse<DisabilitySupport.DAL.Models.Enumerations.RequestStatus>(src.Status)));

            CreateMap<DisabledRequest, DisabledRequestDto>()
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
               .ReverseMap()
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src =>
                Enum.Parse<DisabilitySupport.DAL.Models.Enumerations.RequestStatus>(src.Status)));

            CreateMap<DisabledRequest, DisabledRequestByIdDetailsDto>()
              .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
              .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src =>
                  src.HelperService != null ? src.HelperService.ServiceCategoryId : (int?)null))
              .ForMember(dest => dest.HelperName, opt => opt.MapFrom(src =>
                  src.HelperService != null && src.HelperService.Helper != null && src.HelperService.Helper.User != null
                      ? src.HelperService.Helper.User.FullName : null))
              .ForMember(dest => dest.HelperImage, opt => opt.MapFrom(src =>
                  src.HelperService != null && src.HelperService.Helper != null && src.HelperService.Helper.User != null
                      ? src.HelperService.Helper.User.ProfileImage : null))
              .ForMember(dest => dest.serviceDescription, opt => opt.MapFrom(src =>
                  src.HelperService != null ? src.HelperService.Description : null))
              .ForMember(dest => dest.pricePerHour, opt => opt.MapFrom(src =>
                  src.HelperService != null ? src.HelperService.PricePerHour : (decimal?)null))
              .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src =>
                  src.HelperService != null && src.HelperService.ServiceCategory != null
                      ? src.HelperService.ServiceCategory.Name : null))
              .ForMember(dest => dest.availableDateFrom, opt => opt.MapFrom(src =>
                  src.HelperService != null ? src.HelperService.AvailableDateFrom : (DateTime?)null))
              .ForMember(dest => dest.availableDateTo, opt => opt.MapFrom(src =>
                  src.HelperService != null ? src.HelperService.AvailableDateTo : (DateTime?)null))
              .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src =>
                  src.Disabled != null && src.Disabled.User != null ? src.Disabled.User.FullName: null))
              .ForMember(dest => dest.HelperUserId, opt => opt.MapFrom(src =>
                 src.HelperService != null && src.HelperService.Helper != null
                  ? src.HelperService.Helper.UserId : null))
              .ReverseMap()
              .ForMember(dest => dest.Status, opt => opt.MapFrom(src =>
                  Enum.Parse<DisabilitySupport.DAL.Models.Enumerations.RequestStatus>(src.Status, true)));

            #endregion
           


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

            CreateMap<Helper, HelperDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.FullName))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.User.Address))
            .ForMember(dest => dest.Zone, opt => opt.MapFrom(src => src.User.Zone))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.User.DateOfBirth))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.User.Gender))
            .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.User.ProfileImage))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.User.CreatedAt));


            CreateMap<Payment, PaymentResponseDto>()
                 .ForMember(dest => dest.PaymentId, opt => opt.MapFrom(src => src.Id));












          CreateMap<UpdateHelperServiceDto, HelperService>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<HelperServiceStatus>(src.Status, true)))
            .ReverseMap()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
                }
    }
}
