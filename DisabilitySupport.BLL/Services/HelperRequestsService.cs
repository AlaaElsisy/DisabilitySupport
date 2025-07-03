using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DisabilitySupport.BLL.DTOs.helper.service;
using DisabilitySupport.BLL.DTOs;
using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.DAL.Interfaces;
using DisabilitySupport.DAL.Models;
using DisabilitySupport.BLL.DTOs.helper.Request;
using DisabilitySupport.DAL.Models.Enumerations;

namespace DisabilitySupport.BLL.Services
{
    public class HelperRequestsService : IHelperRequestsService
    {

        private readonly IMapper _mapper;
        public IUnitOfWork _unitOfWork { get; }
        public HelperRequestsService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<HelperRequestDto> AddAsync(HelperRequestDto dto)
        {
            if (dto.DisabledOfferId.HasValue)
            {
                var exists = await _unitOfWork._helperRequestRepository.DisabledOffersExixts(dto.DisabledOfferId.Value);
                if (!exists)
                    throw new KeyNotFoundException($"DisabledOffer with ID {dto.DisabledOfferId.Value} does not exist.");
            }
            if (!Enum.IsDefined(typeof(HelperRequestStatus), dto.Status))
            {
                throw new ArgumentException("Invalid status.");
            }

            var Request = _mapper.Map<HelperRequest>(dto);
                await _unitOfWork._helperRequestRepository.Add(Request);
                await _unitOfWork.Save();

                return _mapper.Map<HelperRequestDto>(Request);
        }

       

        public async Task<HelperRequestDto> GetByIdAsync(int id)
        {
            var exists = await _unitOfWork._helperRequestRepository.RequestExixts(id);
            if (!exists)
                throw new KeyNotFoundException($"Request with ID {id} does not exist.");

            var Request = await _unitOfWork._helperRequestRepository.GetById(id);

            if (Request == null)
                throw new KeyNotFoundException("No Request with that ID");

            return _mapper.Map<HelperRequestDto>(Request);
        }


        public async Task<HelperRequestDto> UpdateAsync(UpdateHelperRequestDto dto)
        {
            var Reques = await _unitOfWork._helperRequestRepository.GetById(dto.Id);

            if (Reques == null)
                throw new KeyNotFoundException("No Reques with that id");
            if (!Enum.IsDefined(typeof(HelperRequestStatus), dto.Status))
            {
                throw new ArgumentException("Invalid status.");
            }

            var result = _mapper.Map(dto, Reques);
            if (result == null)
                throw new ApplicationException("error in mapping result is null ");
            await _unitOfWork._helperRequestRepository.Update(result);
            await _unitOfWork.Save();


            return _mapper.Map<HelperRequestDto>(result);


        }

        public async Task<bool> DeleteAsync(int id)
        {
            var Request = await _unitOfWork._helperRequestRepository.GetById(id);

            if (Request == null)
                throw new KeyNotFoundException("No Request with that ID");

            await _unitOfWork._helperRequestRepository.Delete(id);
            await _unitOfWork.Save();

            return true;

        }

        public async Task<HelperRequestDto> UpdateStatusAsync(int requestId, HelperRequestStatus status)
        {
            var Request = await _unitOfWork._helperRequestRepository.GetById(requestId);
            if (Request == null)
                throw new KeyNotFoundException("No Request with that ID");


            if (!Enum.IsDefined(typeof(HelperRequestStatus), status))
            {
                throw new ArgumentException("Invalid status.");
            }
            Request.Status = status;

            await _unitOfWork.Save();
            return _mapper.Map<HelperRequestDto>(Request);
        }
        public async Task<PaginatedResult<HelperRequestDto>> GetPagedByHelperIdAsync(
                 int helperId, int pageNumber = 1, int pageSize = 10)
        {

            if (!await _unitOfWork._helperRequestRepository.HelperExists(helperId))
                throw new KeyNotFoundException($"Helper with ID {helperId} does not exist.");

            var (items, totalCount) = await _unitOfWork._helperRequestRepository
                .GetPagedByHelperIdAsync(helperId, pageNumber, pageSize);

            if (items == null || !items.Any())
                throw new KeyNotFoundException("No Request found for this helper");

            var result = new PaginatedResult<HelperRequestDto>
            {
                Items = _mapper.Map<List<HelperRequestDto>>(items),
                TotalCount = totalCount
            };

            return result;

        }

        public async Task<PaginatedResult<HelperRequestDetailsDto>> GetPagedAsync(HelperRequestQueryDto query)
        {
            if (query.HelperId.HasValue)
            {
                var exists = await _unitOfWork._helperRequestRepository.HelperExists(query.HelperId.Value);
                if (!exists)
                    throw new KeyNotFoundException($"Helper with ID {query.HelperId} does not exist.");
            }

            var (entities, totalCount) = await _unitOfWork._helperRequestRepository.GetPagedAsync(
                query.HelperId,
                query.DisabledOfferId,
                query.Status,
                query.SearchWord,
                query.MinTotalPrice,
                query.MaxTotalPrice,
                query.OrderBy,
                query.PageNumber,
                query.PageSize
            );

            var items = _mapper.Map<List<HelperRequestDetailsDto>>(entities);

            return new PaginatedResult<HelperRequestDetailsDto>
            {
                Items = items,
                TotalCount = totalCount
            };
        }

    


    }
}
