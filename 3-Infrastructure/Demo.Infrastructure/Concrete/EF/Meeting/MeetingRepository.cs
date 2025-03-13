using Demo.Core.DataAccess.EntityFramework;
using Demo.Infrastructure.Context;
using Demo.Infrastructure.Abstract.Meeting;

namespace Demo.Infrastructure.Concrete.EF.Meeting
{
    internal class MeetingRepository : EfEntityRepositoryBase<Entities.Models.Meeting, DemoContext>, IMeetingRepository
    {
        public Entities.Models.Meeting Get(Guid id)
        {
            using (var context = new DemoContext())
            {
                return context.Meetings.Where(x => x.Id == id).FirstOrDefault();
            }
        }
    }
}
