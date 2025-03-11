using FluentValidation;
using Demo.DTO.User;
using Demo.Business.Abstract.Messages;
using Demo.Core.Constants;
using Demo.DTO.Auth;

namespace Demo.Business.Validations
{
    public class LoginDtoForgetPasswordValidator : AbstractValidator<LoginUser>
    {   
        public LoginDtoForgetPasswordValidator(IMessageManager messageManager)
        {
            
            RuleFor(s => s.Mail).NotEmpty().WithMessage(MessageCodes.EMailIsRequired).EmailAddress().WithMessage(messageManager.Message(MessageCodes.InvalidEMail));
        }
    }
}
