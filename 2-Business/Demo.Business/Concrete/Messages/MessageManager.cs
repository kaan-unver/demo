using AutoMapper;
using Microsoft.AspNetCore.Http;
using Demo.Business.Abstract.Messages;
using Demo.Business.Helper;
using Demo.Caching.Messages;
using Demo.Core.Constants;
using Demo.Core.Models;
using Demo.Core.Utilities.Results;
using Demo.DTO.Messages;
using Demo.Infrastructure.Abstract.Messages;

namespace Demo.Business.Concrete.Messages
{
    public class MessageManager : ContextHelper, IMessageManager
    {
        private readonly IMessageCacheService _messageCaching;
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        public MessageManager(IHttpContextAccessor httpContextAccessor, IMapper mapper, IMessageCacheService messageCaching, IMessageRepository messageRepository) : base(httpContextAccessor)
        {
            _messageCaching = messageCaching;
            _messageRepository = messageRepository;
            _mapper = mapper;
        }
        public string Message(string code, string language = Constants.DefaultLangu)
        {
            var response = _messageCaching.GetMessages(language);
            if (response.Success)
            {
                var message = response.Data.Where(p => p.Code == code).FirstOrDefault();
                if (message != null)
                    return message.Desc;
            }
            return code;
        }
        public IDataResult<List<MessagesDto>> GetActions()
        {
            var response = _messageRepository.GetActionsByLangu(User.Langu);
            if (response != null && response.Any())
                return new SuccessDataResult<List<MessagesDto>>(_mapper.Map<List<Entities.Models.Message>, List<MessagesDto>>(response), Constants.Ok);

            return new ErrorDataResult<List<MessagesDto>>(Constants.Ok, MessageCode, TransactionId, MessageCodes.NotFound);
        }
        public IDataResult<List<MessagesDto>> GetScreenNames()
        {
            var response = _messageRepository.GetScreenNamesByLangu(User.Langu);
            if (response != null && response.Any())
                return new SuccessDataResult<List<MessagesDto>>(_mapper.Map<List<Entities.Models.Message>, List<MessagesDto>>(response), Constants.Ok);

            return new ErrorDataResult<List<MessagesDto>>(Constants.Ok, MessageCode, TransactionId, MessageCodes.NotFound);
        }
        public IDataResult<List<MessagesDto>> GetModuleNames()
        {
            var response = _messageRepository.GetModuleNamesByLangu(User.Langu);
            if (response != null && response.Any())
                return new SuccessDataResult<List<MessagesDto>>(_mapper.Map<List<Entities.Models.Message>, List<MessagesDto>>(response), Constants.Ok);

            return new ErrorDataResult<List<MessagesDto>>(Constants.Ok, MessageCode, TransactionId, MessageCodes.NotFound);
        }
    }
}
