using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.BLL.DTOs;
using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.DAL.Interfaces;
using DisabilitySupport.DAL.Models;
using DisabilitySupport.DAL.Models.Enumerations;
using AutoMapper;

namespace DisabilitySupport.BLL.Services
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceRequestService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DisabledRequestDto> CreateAsync(DisabledRequestDto dto)
        {
            var entity = _mapper.Map<DisabledRequest>(dto);
            await _unitOfWork._disabledRequestRepository.Add(entity);
            await _unitOfWork._disabledRequestRepository.Save();
            return _mapper.Map<DisabledRequestDto>(entity);
        }

        public async Task<DisabledRequestDto> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork._disabledRequestRepository.GetById(id);
            if (entity == null) return null;
            return _mapper.Map<DisabledRequestDto>(entity);
        }

        public async Task<bool> UpdateStatusAsync(int requestId, RequestStatus status)
        {
            var entity = await _unitOfWork._disabledRequestRepository.GetById(requestId);
            if (entity == null) return false;
            entity.Status = status;
            await _unitOfWork._disabledRequestRepository.Update(entity);
            await _unitOfWork._disabledRequestRepository.Save();
            return true;
        }

        public async Task<bool> UpdateAsync(DisabledRequestDto dto)
        {
            if (dto.Id == null)
                return false;
            var entity = await _unitOfWork._disabledRequestRepository.GetById(dto.Id.Value);
            if (entity == null) return false;
            _mapper.Map(dto, entity);
            await _unitOfWork._disabledRequestRepository.Update(entity);
            await _unitOfWork._disabledRequestRepository.Save();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _unitOfWork._disabledRequestRepository.Delete(id);
            await _unitOfWork._disabledRequestRepository.Save();
            return true;
        }

        public async Task<PaginatedResult<DisabledRequestDto>> GetPagedAsync(DisabledRequestQueryDto query)
        {
            var entities = await _unitOfWork._disabledRequestRepository.GetAll();
            var filtered = entities.AsQueryable();

            if (query.DisabledId.HasValue)
                filtered = filtered.Where(x => x.DisabledId == query.DisabledId.Value);
            if (query.HelperServiceId.HasValue)
                filtered = filtered.Where(x => x.HelperServiceId == query.HelperServiceId.Value);
            if (!string.IsNullOrEmpty(query.Status))
                filtered = filtered.Where(x =>x.Status.ToString().ToLower() == query.Status.ToLower());
            if (!string.IsNullOrEmpty(query.SearchWord))
                filtered = filtered.Where(x => (x.Description != null && x.Description.ToLower().Contains(query.SearchWord.ToLower())));

            var totalCount = filtered.Count();
            var items = filtered
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .Select(_mapper.Map<DisabledRequestDto>)
                .ToList();

            return new PaginatedResult<DisabledRequestDto>
            {
                Items = items,
                TotalCount = totalCount
            };
        }
    }
}
