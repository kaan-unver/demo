using Microsoft.Extensions.Caching.Memory;
using Demo.Caching.Common;
using Demo.Core.Constants;
using Demo.Core.Utilities.Results;
using Demo.Entities.Models;
using Demo.Infrastructure.Abstract.Messages;

namespace Demo.Caching.Messages
{
    public class MessageCacheService : IMessageCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IMessageRepository _messageRepository;
        public MessageCacheService(IMemoryCache memoryCache,IMessageRepository messageRepository)
        { 
            _memoryCache = memoryCache;
            _messageRepository = messageRepository;
        }
        public IDataResult<List<Message>> GetMessages(string langu)
        {
            if (!_memoryCache.TryGetValue("messages", out _))
                _memoryCache.Set("messages", _messageRepository.GetMesssageByLangu(langu), CacheItem.CacheOption());

            List<Message> response = _memoryCache.Get<List<Message>>("messages");
            if (response != null)
                return new SuccessDataResult<List<Message>>(response, Constants.Ok);

            return new ErrorDataResult<List<Message>>(Constants.InternalServer);
        }
    }
}
