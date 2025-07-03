using DisabilitySupport.BLL.DTOs;
using DisabilitySupport.DAL.Models;
using DisabilitySupport.DAL.Models.Enumerations;

namespace DisabilitySupport.BLL.Interfaces
{
    public interface IDisabledOfferService
    {
        Task<PaginatedResult<DisabledOfferDto>> GetPagedAsync(DisabledOfferQueryDto query);
        Task<DisabledOfferDto> GetByIdAsync(int id);

        Task<DisabledOfferDto> CreateAsync(DisabledOfferDto dto);
        Task<bool> UpdateAsync(DisabledOfferDto dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateStatusAsync(int offerId, DisabledOfferStatus status);

    }
}
