using Demo.Core.DataAccess.EntityFramework;
using Demo.Entities.Models;
using Demo.Infrastructure.Abstract.Messages;
using Demo.Infrastructure.Constants;
using Demo.Infrastructure.Context;

namespace Demo.Infrastructure.Concrete.EF.Messages
{
    internal class MessageRepository : EfEntityRepositoryBase<Message, DemoContext>, IMessageRepository
    {
        public List<Message> GetMesssageByLangu(string langu)
        {
            using var context = new DemoContext();
            var result = context.Messages.Where(p => p.Langu == langu).ToList();
            return result;
        }
        public List<Message> GetActionsByLangu(string langu)
        {
            using var context = new DemoContext();
            var result = context.Messages.Where(p => p.Langu == langu && p.Code.StartsWith(FixedConditions.ScreenAction)).ToList();
            return result;
        }
        public List<Message> GetScreenNamesByLangu(string langu)
        {
            using var context = new DemoContext();
            var result = context.Messages.Where(p => p.Langu == langu && p.Code.StartsWith(FixedConditions.ScreenName)).ToList();
            return result;
        }
        public List<Message> GetModuleNamesByLangu(string langu)
        {
            using var context = new DemoContext();
            var result = context.Messages.Where(p => p.Langu == langu && p.Code.StartsWith(FixedConditions.ModuleName)).ToList();
            return result;
        }
    }
}
