using Demo.Infrastructure.Abstract.Address;
using Demo.Entities.Models;
using Demo.Infrastructure.Context;
using Demo.Core.DataAccess.EntityFramework;

namespace Demo.Infrastructure.Concrete.EF.Address
{
    internal class CountyRepository : EfEntityRepositoryBase<County, DemoContext>, ICountyRepository
    {
        public List<County>? GetCountiesByCity(int cityId)
        {
            using var context = new DemoContext();
            {
                return context.Counties.Where(p => p.CityId == cityId).ToList();
            }
        }
    }

}
