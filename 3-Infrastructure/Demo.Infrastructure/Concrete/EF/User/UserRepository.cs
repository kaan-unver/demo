using Demo.Entities.Models;
using Demo.Core.DataAccess.EntityFramework;
using Demo.Infrastructure.Context;
using Demo.DTO.User;
using Demo.Infrastructure.Abstract.User;

namespace Demo.Infrastructure.Concrete.EF.User
{
    internal class UserRepository : EfEntityRepositoryBase<Entities.Models.User, DemoContext>, IUserRepository
    {
        public UserDto? GetUserByUserId(Guid userId)
        {
            using var context = new DemoContext();
            {
                var result = from user in context.Tusers.Where(p => p.Id == userId)
                             select new UserDto
                             {
                                 Id = user.Id,
                                 
                             };
                return result.SingleOrDefault();

            }
            return null;
        }
        public UserDetailDto GetUser(string mail, string password)
        {
            using var context = new DemoContext();
            {
                var result = from user in context.Tusers.Where(p => p.Email == mail && p.Password == password)
                             select new UserDetailDto
                             {
                                 Id = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 PhoneNumber = user.PhoneNumber,
                                 MiddleName = user.MiddleName
                             };

                return result.SingleOrDefault();
            }
            return null;
        }
    }
}
