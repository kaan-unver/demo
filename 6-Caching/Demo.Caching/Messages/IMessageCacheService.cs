using Demo.Core.Constants;
using Demo.Core.Utilities.Results;
using Demo.Entities.Models;

namespace Demo.Caching.Messages
{
    public interface IMessageCacheService
    {
        IDataResult<List<Message>> GetMessages(string langu = Constants.DefaultLangu);
    }
}
