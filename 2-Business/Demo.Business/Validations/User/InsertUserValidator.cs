using FluentValidation;
using Demo.Business.Abstract.Messages;
using Demo.Core.Constants;
using Demo.DTO.User;

namespace Demo.Business.Validations.User
{
    internal class InsertUserValidator: AbstractValidator<InsertTUserDto>
    {
        public InsertUserValidator(IMessageManager messageManager)
        {

            RuleFor(s => s.Email).NotEmpty().WithMessage(MessageCodes.EMailIsRequired).EmailAddress().WithMessage(MessageCodes.InvalidEMail);
            RuleFor(s => s.FirstName).NotEmpty().WithMessage(MessageCodes.NameIsRequired);
            RuleFor(s => s.LastName).NotEmpty().WithMessage(MessageCodes.LastNameIsRequired);
        }
    }
}
