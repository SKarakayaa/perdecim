using System;
using System.Linq;
using Core.Utilities.Messages;
using Entities.DTO.Auth;
using FluentValidation;

namespace Business.Validations.Auth
{
    public class RegisterDtoValidation : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.Name).NotNull().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.Name).Must(CheckContainsNumber).WithMessage(ValidationMessages.FieldCantContainDigit);

            RuleFor(x => x.Surname).NotEmpty().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.Surname).NotNull().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.Surname).Must(CheckContainsNumber).WithMessage(ValidationMessages.FieldCantContainDigit);

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.PhoneNumber).NotNull().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.PhoneNumber).Length(10).Must(x => decimal.TryParse(x, out decimal _)).WithMessage(ValidationMessages.MinimumPhoneLength);

            RuleFor(x => x.Email).NotEmpty().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.Email).NotNull().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.Email).EmailAddress().WithMessage(ValidationMessages.NotEmailFormat);

            RuleFor(x => x.UserName).NotEmpty().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.UserName).NotNull().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.UserName).Must(CheckFirstCharacterIsNumber).WithMessage(ValidationMessages.UserNameCantStartWithDigit);

            RuleFor(x => x.Password).NotEmpty().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.Password).NotNull().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.Password).MinimumLength(5).WithMessage(ValidationMessages.MinimumPasswordLength);
        }

        private bool CheckFirstCharacterIsNumber(string arg)
        {
            if (!String.IsNullOrEmpty(arg) && int.TryParse(arg[0].ToString(), out int _))
                return false;
            return true;
        }
        private bool CheckContainsNumber(string arg)
        {
            if (!String.IsNullOrEmpty(arg) && arg.Any(char.IsDigit))
                return false;
            return true;
        }
    }
}