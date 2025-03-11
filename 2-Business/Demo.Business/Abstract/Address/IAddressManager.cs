using Demo.Core.Utilities.Results;
using Demo.DTO.Address;

namespace Demo.Business.Abstract.Address
{
    public interface IAddressManager
    {
        IDataResult<List<CityDto>> GetCities();
        IDataResult<List<CountyDto>> GetCountiesByCity(int cityId);
        IDataResult<List<HometownDto>> GetHometownByCounty(int countyId);
        IDataResult<List<HometownDto>> GetHometowns();
        IDataResult<List<CountyDto>> GetCounties();
    }
}
