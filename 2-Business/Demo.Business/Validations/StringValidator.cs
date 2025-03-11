using FluentValidation;
using Demo.Business.Abstract.Messages;
using Demo.Core.Constants;

namespace Demo.Business.Validations
{
    internal class StringValidator : AbstractValidator<string>
    {
        public StringValidator(IMessageManager messageManager)
        {
            RuleFor(s => s).NotEmpty().WithMessage(MessageCodes.NameIsRequired);
        }
    }
}
