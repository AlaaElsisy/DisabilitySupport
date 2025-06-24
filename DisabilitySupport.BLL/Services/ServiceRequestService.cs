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

        public async Task<IEnumerable<DisabledRequestDto>> GetAllAsync()
        {
            var entities = await _unitOfWork._disabledRequestRepository.GetAll();
            return entities.Select(_mapper.Map<DisabledRequestDto>);
        }

        public async Task<IEnumerable<DisabledRequestDto>> GetByDisabledIdAsync(int disabledId)
        {
            var entities = await _unitOfWork._disabledRequestRepository.GetAll();
            return entities.Where(x => x.DisabledId == disabledId).Select(_mapper.Map<DisabledRequestDto>);
        }

        public async Task<IEnumerable<DisabledRequestDto>> GetByHelperServiceIdAsync(int helperServiceId)
        {
            var entities = await _unitOfWork._disabledRequestRepository.GetAll();
            return entities.Where(x => x.HelperServiceId == helperServiceId).Select(_mapper.Map<DisabledRequestDto>);
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
    }
}
