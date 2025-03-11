using Demo.Core.DataAccess.EntityFramework;
using Demo.Entities.Models;

namespace Demo.Infrastructure.Abstract.Address
{
    public interface IHometownRepository : IEntityRepository<Hometown>
    {
        List<Hometown>? GetHometownsByCounty(int countyId);
    }
}
