using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Business.Abstract.Messages;
using Demo.Core.Constants;
using Demo.DTO.Abstract;

namespace Demo.Business.Validations
{

    internal class DeleteIntEntryValidator : AbstractValidator<List<DeleteIntEntryDto>>
    {
        public DeleteIntEntryValidator(IMessageManager messageManager)
        {
            RuleForEach(model => model).NotNull().WithMessage(MessageCodes.ListCannotBeEmpty);
        }

    }
}
