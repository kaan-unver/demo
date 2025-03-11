using FluentValidation;
using Demo.Business.Abstract.Messages;
using Demo.Core.Constants;

namespace Demo.Business.Validations
{

    internal class IdentifierValidator : AbstractValidator<int>
    {
        public IdentifierValidator(IMessageManager messageManager)
        {
            RuleFor(s => s).NotEmpty().WithMessage(MessageCodes.IdIsRequiered);
        }
    }
}
