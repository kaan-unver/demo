using Demo.Core.DataAccess.EntityFramework;
using Demo.Entities.Models;

namespace Demo.Infrastructure.Abstract.Messages
{
    public interface IMessageRepository : IEntityRepository<Message>
    {
        List<Message> GetMesssageByLangu(string langu);
        List<Message> GetActionsByLangu(string langu);
        List<Message> GetScreenNamesByLangu(string langu);
        List<Message> GetModuleNamesByLangu(string langu);
    }
}
