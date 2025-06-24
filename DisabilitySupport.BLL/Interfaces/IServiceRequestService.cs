using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DisabilitySupport.BLL.DTOs;

using DisabilitySupport.DAL.Models.Enumerations;

namespace DisabilitySupport.BLL.Interfaces
{
    public interface IServiceRequestService
    {
        Task<DisabledRequestDto> CreateAsync(DisabledRequestDto dto);
        Task<DisabledRequestDto> GetByIdAsync(int id);
        Task<bool> UpdateStatusAsync(int requestId, RequestStatus status);
        Task<bool> UpdateAsync(DisabledRequestDto dto);
        Task<bool> DeleteAsync(int id);
        Task<PaginatedResult<DisabledRequestDto>> GetPagedAsync(DisabledRequestQueryDto query);
    }
}
