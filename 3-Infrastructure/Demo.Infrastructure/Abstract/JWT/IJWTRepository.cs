using Demo.Core.DataAccess.EntityFramework;
using Demo.Entities.Models;

namespace Demo.Infrastructure.Abstract.JWT
{
    public interface IJWTRepository : IEntityRepository<CurrentJwt>
    {
        bool CheckTokenIsTheSame(string token, Guid userId);
        CurrentJwt GetCurrentTokenByUser(Guid userId);
        bool AddJwtIfExist(CurrentJwt newJwt, CurrentJwt currentJwt);
    }
}
