using Demo.Infrastructure.Abstract.Address;
using Demo.Entities.Models;
using Demo.Infrastructure.Context;
using Demo.Core.DataAccess.EntityFramework;

namespace Demo.Infrastructure.Concrete.EF.Address
{
    internal class HometownRepository : EfEntityRepositoryBase<Hometown, DemoContext>, IHometownRepository
    {
        public List<Hometown>? GetHometownsByCounty(int countyId)
        {
            using var context = new DemoContext();
            {
                return context.Hometowns.Where(p => p.CountyId   == countyId).ToList();
            }
        }
    }
}
