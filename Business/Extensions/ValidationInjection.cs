using Business.Validations.Auth;
using Entities.DTO.Auth;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions
{
    public static class ValidationInjection
    {
        public static void AddValidationInjection(this IServiceCollection services)
        {
            services.AddTransient<IValidator<RegisterDto>,RegisterDtoValidation>();
        }
    }
}