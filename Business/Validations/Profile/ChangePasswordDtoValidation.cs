using Core.Utilities.Messages;
using Entities.DTO.Profile;
using FluentValidation;

namespace Business.Validations.Profile
{
    public class ChangePasswordDtoValidation : AbstractValidator<ChangePasswordDTO>
    {
        public ChangePasswordDtoValidation()
        {
            RuleFor(x => x.CurrentPassword).NotEmpty().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.CurrentPassword).NotNull().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.CurrentPassword).MinimumLength(5).WithMessage(ValidationMessages.MinimumPasswordLength);

            RuleFor(x => x.NewPassword).NotEmpty().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.NewPassword).NotNull().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.NewPassword).MinimumLength(5).WithMessage(ValidationMessages.MinimumPasswordLength);

            RuleFor(x => x.NewPasswordConfirm).NotEmpty().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.NewPasswordConfirm).NotNull().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.NewPasswordConfirm).MinimumLength(5).WithMessage(ValidationMessages.MinimumPasswordLength);
        }
    }
}