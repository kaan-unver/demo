using Demo.Core.DataAccess.EntityFramework;
using Demo.Infrastructure.Abstract.Address;
using Demo.Infrastructure.Context;

namespace Demo.Infrastructure.Concrete.EF.Address
{
    internal class CityRepository : EfEntityRepositoryBase<Entities.Models.City, DemoContext>, ICityRepository
    {
    }
}
