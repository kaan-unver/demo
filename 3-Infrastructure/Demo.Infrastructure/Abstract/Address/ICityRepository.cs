using Demo.Core.DataAccess.EntityFramework;
using Demo.Entities.Models;
using Demo.Infrastructure.Context;

namespace Demo.Infrastructure.Abstract.Address
{
    public interface ICityRepository : IEntityRepository<City>
    {
        public List<Hometown>? GetHometownsByCounty(int countyId)
        {
            using var context = new DemoContext();
            {
                return context.Hometowns.Where(p => p.CountyId == countyId).ToList();
            }
        }
    }
}
