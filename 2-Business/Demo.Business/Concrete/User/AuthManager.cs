using Microsoft.AspNetCore.Http;
using AutoMapper;
using Demo.Business.Helper;
using Demo.Business.Abstract.UserManager;
using Demo.Core.ConfigManager;
using Demo.Infrastructure.Abstract.User;
using Demo.Infrastructure.Abstract.JWT;
using Demo.Business.Abstract.Messages;
using Demo.Business.Abstract.JWT;
using Demo.Core.Utilities.Results;
using Demo.DTO.Auth;
using Demo.DTO.User;
using Demo.Business.Validations;
using Demo.Core.Constants;

namespace Xeneff.Business.Concrete.User
{
    internal class AuthManager : ContextHelper, IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly IConfigManager _config;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;

        private readonly IJWTRepository _jwtRepository;
        private readonly IMessageManager _messageManager;
        private readonly IJWTManager _tokenManager;

        public AuthManager(IHttpContextAccessor httpContextAccessor, IMapper mapper, IConfigManager config, IMessageManager messageManager, IJWTManager tokenManager,
           IUserRepository userRepository) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _messageManager = messageManager;
            _tokenManager = tokenManager;

        }

        //TODO: gülsüm kod tekrarı var bu kısımları düzenlemelisin şuan işlemi ilerletmek için bu şekilde bırakıyorum
        public IDataResult<UserLoginResponseDto> GetUserByLogin(LoginUser dto)
        {
            var result = new LoginDtoValidator(_messageManager).Validate(dto);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                return new ErrorDataResult<UserLoginResponseDto>(Constants.BadRequest, MessageCode!, TransactionId!, errors);
            }
            var user = GetUserByLoginDto(dto);
            if (user == null)
                return new ErrorDataResult<UserLoginResponseDto>(Constants.UnAuthorized, MessageCode!, TransactionId!, MessageCodes.UserNotFound);

            var userDetail = _mapper.Map<UserDetailDto, UserLoginResponseDto>(user);

            var token = _tokenManager.GetToken(user.Id);
            if (!token.Success)
                return new ErrorDataResult<UserLoginResponseDto>(Constants.InternalServer, token.Code, token.TransactionId, token.Messages);

            userDetail.Token = token.Data;

            return new SuccessDataResult<UserLoginResponseDto>(userDetail, Constants.Ok);

        }
        public IDataResult<UserDto> GetUserByUserId(Guid userId, string tokenType)
        {
            var user = _userRepository.GetUserByUserId(userId);
            if (user == null)
                return new ErrorDataResult<UserDto>(Constants.UnAuthorized, MessageCode!, TransactionId!, MessageCodes.UserNotFound);

            return new SuccessDataResult<UserDto>(_mapper.Map<UserDto, UserDto>(user), Constants.Ok);

        }


        
        #region "Private Methods"  
        
        private UserDetailDto? GetUserByLoginDto(LoginUser dto)
        {
            var mappedData = _mapper.Map<LoginUser, LoginUser>(dto);
            var user = _userRepository.GetUser(mappedData.Mail, mappedData.Password);
            return user;
        }

        #endregion

    }
}
