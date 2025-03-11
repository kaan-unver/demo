using Demo.Entities.Models;
using Demo.Core.DataAccess.EntityFramework;
using Demo.Infrastructure.Context;
using Demo.Infrastructure.Abstract.JWT;

namespace Demo.Infrastructure.Concrete.EF.JWT
{
    internal class JWTRepository : EfEntityRepositoryBase<CurrentJwt, DemoContext>, IJWTRepository
    {
        public bool CheckTokenIsTheSame(string token, Guid userId)
        {
            using var context = new DemoContext();
            var result = context.CurrentJwts.Where(p => p.Token == token && p.UserId == userId && !p.IsDeleted).Any();
            return result;
        }
        public CurrentJwt GetCurrentTokenByUser(Guid userId)
        {
            using var context = new DemoContext();
            var result = context.CurrentJwts.Where(p => p.UserId == userId && !p.IsDeleted).FirstOrDefault();
            return result;
        }
        public bool AddJwtIfExist(CurrentJwt newJwt, CurrentJwt currentJwt)
        {
            using (var context = new DemoContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    Delete(currentJwt);

                    context.CurrentJwts.Add(new CurrentJwt()
                    {
                        UserId = newJwt.UserId,
                        CreatedBy = newJwt.CreatedBy,
                        CreatedDate = newJwt.CreatedDate,
                        Token = newJwt.Token
                    });
                    context.SaveChanges();

                    context.Jwthistories.Add(new Jwthistory()
                    {
                        UserId = currentJwt.UserId,
                        CreatedBy = currentJwt.CreatedBy,
                        CreatedDate = currentJwt.CreatedDate,
                        Token = currentJwt.Token
                    });

                    context.SaveChanges();
                    dbContextTransaction.Commit();

                    return true;
                }
            }
            return false;
        }


    }
}
