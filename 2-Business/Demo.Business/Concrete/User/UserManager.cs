using AutoMapper;
using Demo.Business.Abstract.Messages;
using Demo.Business.Abstract.User;
using Demo.Business.Helper;
using Demo.Business.Helpers;
using Demo.Business.Validations.User;
using Demo.Core.ConfigManager;
using Demo.Core.Constants;
using Demo.Core.Utilities.Results;
using Demo.DTO.User;
using Demo.Entities.Models;
using Demo.Infrastructure.Abstract.User;
using Microsoft.AspNetCore.Http;

namespace Xeneff.Business.Concrete.User
{
    internal class UserManager : ContextHelper, IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IMessageManager _messageManager;
        private readonly IConfigManager _configManager;
        private readonly IMapper _mapper;

        public UserManager(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository,
           IMessageManager messageManager, IConfigManager configManager, IMapper mapper) : base(httpContextAccessor)
        {
            _userRepository = userRepository;
            _messageManager = messageManager;
            _mapper = mapper;
            _configManager = configManager;
        }

        public IDataResult<TUserDto> Add(InsertTUserDto dto)
        {
            var result = new InsertUserValidator(_messageManager).Validate(dto);
            if (!result.IsValid)
                return new ErrorDataResult<TUserDto>(Constants.BadRequest, MessageCode, TransactionId, result.Errors.Select(x => x.ErrorMessage).ToList());

            var data = _mapper.Map<InsertTUserDto, Demo.Entities.Models.User>(dto, opt => opt.AfterMap((src, dest) =>
            {
                dest.PPId = Guid.Parse(FileHelper.SaveImage(src.ProfilePhoto, _configManager.ProfilePhotoFilePath).Result);

            }));

            var response = _userRepository.Add(data);
            return new ErrorDataResult<TUserDto>(Constants.InternalServer, MessageCode, TransactionId, MessageCodes.InsertError);
        }

    }
}
