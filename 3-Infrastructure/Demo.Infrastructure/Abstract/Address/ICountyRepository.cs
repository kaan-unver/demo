using Demo.Core.DataAccess.EntityFramework;
using Demo.Entities.Models;

namespace Demo.Infrastructure.Abstract.Address
{
    public interface ICountyRepository : IEntityRepository<County>
    {
        List<County>? GetCountiesByCity(int cityId);
    }
}
