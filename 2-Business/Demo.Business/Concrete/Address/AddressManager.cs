using AutoMapper;
using Microsoft.AspNetCore.Http;
using Demo.Business.Abstract.Address;
using Demo.Business.Abstract.Messages;
using Demo.Business.Helper;
using Demo.Core.Constants;
using Demo.Core.Utilities.Results;
using Demo.DTO.Address;
using Demo.Entities.Models;
using Demo.Infrastructure.Abstract.Address;

namespace Demo.Business.Concrete.Address
{
    internal class AddressManager : ContextHelper, IAddressManager
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICountyRepository _countyRepository;
        private readonly IHometownRepository _hometownRepository;
        private readonly IMessageManager _messageManager;
        private readonly IMapper _mapper;
        public AddressManager(IHttpContextAccessor httpContextAccessor, ICityRepository cityRepository, ICountyRepository countyRepository,
            IHometownRepository hometownRepository, IMapper mapper, IMessageManager messageManager) : base(httpContextAccessor)
        {
            _cityRepository = cityRepository;
            _countyRepository = countyRepository;
            _hometownRepository = hometownRepository;
            _mapper = mapper;
            _messageManager = messageManager;
        }

        public IDataResult<List<CityDto>> GetCities()
        {
            var data = _mapper.Map<List<City>, List<CityDto>>(_cityRepository.GetAll());
            if (data == null || !data.Any())
                return new ErrorDataResult<List<CityDto>>(Constants.Ok, MessageCode, TransactionId, _messageManager.Message(MessageCodes.NotFound));
            return new SuccessDataResult<List<CityDto>>(data, Constants.Ok);

        }
        public IDataResult<List<CountyDto>> GetCounties()
        {
            var data = _mapper.Map<List<County>, List<CountyDto>>(_countyRepository.GetAll());
            if (data == null || !data.Any())
                return new ErrorDataResult<List<CountyDto>>(Constants.Ok, MessageCode, TransactionId, _messageManager.Message(MessageCodes.NotFound));
            return new SuccessDataResult<List<CountyDto>>(data, Constants.Ok);

        }
        public IDataResult<List<CountyDto>> GetCountiesByCity(int cityId)
        {
            var data = _mapper.Map<List<County>, List<CountyDto>>(_countyRepository.GetCountiesByCity(cityId));
            if (data == null || !data.Any())
                return new ErrorDataResult<List<CountyDto>>(Constants.Ok, MessageCode, TransactionId, _messageManager.Message(MessageCodes.NotFound));

            return new SuccessDataResult<List<CountyDto>>(data, Constants.Ok);
        }
        public IDataResult<List<HometownDto>> GetHometownByCounty(int countyId)
        {
            var data = _mapper.Map<List<Hometown>, List<HometownDto>>(_hometownRepository.GetHometownsByCounty(countyId));
            if (data == null || !data.Any())
                return new ErrorDataResult<List<HometownDto>>(Constants.Ok, MessageCode, TransactionId, _messageManager.Message(MessageCodes.NotFound));

            return new SuccessDataResult<List<HometownDto>>(data, Constants.Ok);
        }
        public IDataResult<List<HometownDto>> GetHometowns()
        {
            var data = _mapper.Map<List<Hometown>, List<HometownDto>>(_hometownRepository.GetAll());
            if (data == null || !data.Any())
                return new ErrorDataResult<List<HometownDto>>(Constants.Ok, MessageCode, TransactionId, _messageManager.Message(MessageCodes.NotFound));

            return new SuccessDataResult<List<HometownDto>>(data, Constants.Ok);
        }
    }
}
