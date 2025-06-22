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
        
        
        }


    }
}
