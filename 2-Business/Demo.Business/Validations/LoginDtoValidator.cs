using FluentValidation;
using Demo.DTO.User;
using Demo.Business.Abstract.Messages;
using Demo.Core.Constants;
using Demo.DTO.Auth;

namespace Demo.Business.Validations
{
    public class LoginDtoValidator:AbstractValidator<LoginUser>
    {   
        public LoginDtoValidator(IMessageManager messageManager)
        {
            
            RuleFor(s => s.Mail).NotEmpty().WithMessage(MessageCodes.EMailIsRequired).EmailAddress().WithMessage(MessageCodes.InvalidEMail);
            RuleFor(x => x.Password).NotEmpty().WithMessage(MessageCodes.PasswordIsRequired);
        }
    }
}
