using Core.Utilities.Messages;
using Entities.DTO.Address;
using FluentValidation;

namespace Business.Validations.Address
{
    public class UserAddressCreateUpdateDtoValidation : AbstractValidator<UserAddressCreateUpdateDTO>
    {
        public UserAddressCreateUpdateDtoValidation()
        {
            RuleFor(x => x.AddressType).NotNull().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.AddressType).NotEmpty().WithMessage(ValidationMessages.RequiredField);

            RuleFor(x => x.CityId).NotNull().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.CityId).NotEmpty().WithMessage(ValidationMessages.RequiredField);

            RuleFor(x => x.DistrictId).NotNull().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.DistrictId).NotEmpty().WithMessage(ValidationMessages.RequiredField);

            RuleFor(x => x.NeighborhoodId).NotNull().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.NeighborhoodId).NotEmpty().WithMessage(ValidationMessages.RequiredField);

            RuleFor(x => x.OpenAddress).NotNull().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.OpenAddress).NotEmpty().WithMessage(ValidationMessages.RequiredField);
        }
    }
}