using Demo.Core.DataAccess.EntityFramework;
using Demo.DTO.User;
using Demo.Entities.Models;

namespace Demo.Infrastructure.Abstract.Meeting
{
    public interface IMeetingRepository : IEntityRepository<Entities.Models.Meeting>
    {
        Entities.Models.Meeting Get(Guid id);

    }
}
