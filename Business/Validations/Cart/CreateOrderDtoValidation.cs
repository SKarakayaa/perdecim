using Core.Utilities.Messages;
using Entities.DTO.Cart;
using FluentValidation;

namespace Business.Validations.Cart
{
    public class CreateOrderDtoValidation : AbstractValidator<CreateOrderDto>
    {
        public CreateOrderDtoValidation()
        {
            RuleFor(x => x.AddressId).NotEqual(0).WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.PaymentType).NotEqual(0).WithMessage(ValidationMessages.RequiredField);
        }
    }
}