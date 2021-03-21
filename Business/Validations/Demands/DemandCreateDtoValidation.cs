using System;
using Core.Utilities.Messages;
using Entities.DTO.Demand;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.Validations.Demands
{
    public class DemandCreateDtoValidation : AbstractValidator<DemandCreateDto>
    {
        public DemandCreateDtoValidation()
        {
            RuleFor(x => x.DemandTypeId).NotEmpty().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.DemandTypeId).NotNull().WithMessage(ValidationMessages.RequiredField);

            RuleFor(x => x.Name).NotNull().WithMessage(ValidationMessages.RequiredField);
            RuleFor(x => x.Name).NotNull().WithMessage(ValidationMessages.RequiredField);

            RuleFor(x => x.Image).Must(CheckContentType).WithMessage(ValidationMessages.WrongContentType);
        }

        private bool CheckContentType(IFormFile arg)
        {
            if (arg.ContentType == "image/jpg" || arg.ContentType == "image/jpeg" || arg.ContentType == "image/png")
                return true;
            return false;
        }
    }
}