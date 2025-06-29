using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.BLL.DTOs;
using DisabilitySupport.BLL.DTOs.helper.service;
using DisabilitySupport.DAL.Models;
using DisabilitySupport.DAL.Models.Enumerations;

namespace DisabilitySupport.BLL.Interfaces
{
    public interface IHelperServicesService
    {
        Task <HelperServiceDto> AddAsync(HelperServiceDto dto);
        Task<List<HelperService>> GetByHelperIdAsync(int helperId);


        Task<HelperServiceDto> GetByIdAsync(int id);
       
        Task<HelperServiceDto> UpdateAsync(UpdateHelperServiceDto dto);
        Task<bool> DeleteAsync(int id);

        public  Task<PaginatedResult<HelperServiceDto>> GetPagedByHelperIdAsync(int helperId, int pageNumber = 1, int pageSize = 10);

        public Task<PaginatedResult<HelperServiceDetailsDto>> GetPagedAsync(HelperServiceQueryDto query);

    //Task AddHelperRequestAsync(HelperRequestDto dto);
    //Task<List<HelperRequest>> GetRequestsByHelperIdAsync(int helperId);
}
}
