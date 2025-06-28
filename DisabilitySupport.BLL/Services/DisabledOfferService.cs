using AutoMapper;
using DisabilitySupport.BLL.DTOs;
using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.DAL.Interfaces;
using DisabilitySupport.DAL.Models;
using DisabilitySupport.DAL.Models.Enumerations;

namespace DisabilitySupport.BLL.Services
{
    public class DisabledOfferService : IDisabledOfferService
    {
        private readonly IDisabledOfferRepository _repository;
        private readonly IMapper _mapper;

        public DisabledOfferService(IDisabledOfferRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<DisabledOfferDto>> GetPagedAsync(DisabledOfferQueryDto query)
        {
            var (items, totalCount) = await _repository.GetPagedAsync(
                query.DisabledId,
                query.ServiceCategoryId,
                query.Status,
                query.SearchWord,
                query.PageNumber,
                query.PageSize
            );

            var mapped = _mapper.Map<IEnumerable<DisabledOfferDto>>(items);

            return new PaginatedResult<DisabledOfferDto>
            {
                Items = mapped,
                TotalCount = totalCount
            };
        }

        public async Task<DisabledOfferDto> GetByIdAsync(int id)
        {
            var offer = await _repository.GetById(id);
            return offer == null ? null : _mapper.Map<DisabledOfferDto>(offer);
        }

        public async Task<DisabledOfferDto> CreateAsync(DisabledOfferDto dto)
        {
            var entity = _mapper.Map<DisabledOffer>(dto);
            await _repository.Add(entity);
            await _repository.Save();
            return _mapper.Map<DisabledOfferDto>(entity);
        }

        public async Task<bool> UpdateAsync(DisabledOfferDto dto)
        {
            var entity = await _repository.GetById(dto.Id ?? 0);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _repository.Update(entity);
            await _repository.Save();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetById(id);
            if (entity == null) return false;

            await _repository.Delete(id);
            await _repository.Save();
            return true;
        }
    }
}
