using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.BLL.DTOs.helper.service;
using DisabilitySupport.BLL.DTOs;
using DisabilitySupport.DAL.Models;
using DisabilitySupport.BLL.DTOs.helper.Request;
using DisabilitySupport.DAL.Models.Enumerations;

namespace DisabilitySupport.BLL.Interfaces
{
    public interface IHelperRequestsService
    {
        Task<HelperRequestDto> AddAsync(HelperRequestDto dto);
      
        Task<HelperRequestDto> GetByIdAsync(int id);

        Task<HelperRequestDto> UpdateAsync(UpdateHelperRequestDto dto);
        Task<bool> DeleteAsync(int id);

        Task<HelperRequestDto> UpdateStatusAsync(int requestId, HelperRequestStatus status);

        public Task<PaginatedResult<HelperRequestDto>> GetPagedByHelperIdAsync(int helperId, int pageNumber = 1, int pageSize = 10);

        public Task<PaginatedResult<HelperRequestDetailsDto>> GetPagedAsync(HelperRequestQueryDto query);
        Task<PaginatedResult<HelperRequestCardDto>> GetCardsByHelperIdAsync(int helperId, int pageNumber = 1, int pageSize = 10);

    }
}
