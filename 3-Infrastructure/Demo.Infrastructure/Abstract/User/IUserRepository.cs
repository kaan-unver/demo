using Demo.Core.DataAccess.EntityFramework;
using Demo.DTO.User;
using Demo.Entities.Models;

namespace Demo.Infrastructure.Abstract.User
{
    public interface IUserRepository : IEntityRepository<Entities.Models.User>
    {
        UserDto? GetUserByUserId(Guid userId);
        UserDetailDto GetUser(string mail, string password);
    }
}
