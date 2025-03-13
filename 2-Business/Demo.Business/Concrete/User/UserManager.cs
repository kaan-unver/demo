using AutoMapper;
using Demo.Business.Abstract.Messages;
using Demo.Business.Abstract.User;
using Demo.Business.Emails;
using Demo.Business.Helper;
using Demo.Business.Helpers;
using Demo.Business.Validations.User;
using Demo.Core.ConfigManager;
using Demo.Core.Constants;
using Demo.Core.Utilities.Results;
using Demo.DTO.EMail;
using Demo.DTO.User;
using Demo.Entities.Models;
using Demo.Infrastructure.Abstract.User;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Xeneff.Business.Concrete.User
{
    internal class UserManager(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository,
       IMessageManager messageManager, IConfigManager configManager, IMapper mapper, IEmailService emailService) : ContextHelper(httpContextAccessor), IUserManager
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMessageManager _messageManager = messageManager;
        private readonly IConfigManager _configManager = configManager;
        private readonly IEmailService _emailService = emailService;
        private readonly IMapper _mapper = mapper;

        public IDataResult<TUserDto> Add(InsertTUserDto dto)
        {
            var result = new InsertUserValidator(_messageManager).Validate(dto);
            if (!result.IsValid)
                return new ErrorDataResult<TUserDto>(Constants.BadRequest, MessageCode, TransactionId, result.Errors.Select(x => x.ErrorMessage).ToList());
            if (DoesEMailExist(dto.Email))
                return new ErrorDataResult<TUserDto>(Constants.BadRequest, MessageCode, TransactionId, MessageCodes.EmailExist);

            var data = _mapper.Map<InsertTUserDto, Demo.Entities.Models.User>(dto, opt => opt.AfterMap((src, dest) =>
            {
                dest.PPId = src.ProfilePhoto != null ? Guid.Parse(FileHelper.SaveImage(src.ProfilePhoto, _configManager.ProfilePhotoFilePath).Result) : null;

            }));

            var response = _userRepository.Add(data);
            if (response)
            {
                SendSignUpEMail(data);
                return new SuccessDataResult<TUserDto>(_mapper.Map<Demo.Entities.Models.User, TUserDto>(data), Constants.Ok);
            }else
                return new ErrorDataResult<TUserDto>(Constants.InternalServer, MessageCode, TransactionId, MessageCodes.InsertError);
        }
        #region Private Methods
        private bool DoesEMailExist(string email)
        {
                return _userRepository.GetAll(p => p.Email == email).Any();
        }
        private async Task SendSignUpEMail(Demo.Entities.Models.User data)
        {
            EmailContentDto emailDto = new EmailContentDto();
            emailDto.Subject = Constants.SignUpSuccess;
            emailDto.ContactName = data.FirstName + " " + data.MiddleName + " " + data.LastName;
            emailDto.ContactEmail = data.Email;
            emailDto.TemplatePath = Path.Combine("Emails", "Templates", "SignUp_Template.cshtml");
            bool emailResult = await _emailService.SendSignUpSuccessEmail(emailDto);
        }
        #endregion
    }
}
