using System;
using System.Linq;
using Core.Utilities.Messages;
using Entities.DTO.Demand;
using FluentValidation;

namespace Business.Validations.Demands
{
    public class DemandTypeCreateDtoValidation : AbstractValidator<DemandTypeCreateDto>
    {
        public DemandTypeCreateDtoValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.Name).NotNull().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.Name).Must(CheckContainsNumber).WithMessage("Bu Alan Sayısal İfade Alamaz !");
        }
        private bool CheckContainsNumber(string arg)
        {
            if (!String.IsNullOrEmpty(arg) && arg.Any(char.IsDigit))
                return false;
            return true;
        }
    }
}