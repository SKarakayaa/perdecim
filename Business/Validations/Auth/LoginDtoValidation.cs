using System;
using Core.Utilities.Messages;
using Entities.DTO.Auth;
using FluentValidation;

namespace Business.Validations.Auth
{
    public class LoginDtoValidation : AbstractValidator<LoginDto>
    {
        public LoginDtoValidation()
        {
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
    }
}