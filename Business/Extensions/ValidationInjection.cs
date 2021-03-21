using Business.Validations.Auth;
using Business.Validations.Demands;
using Entities.DTO.Auth;
using Entities.DTO.Demand;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions
{
    public static class ValidationInjection
    {
        public static void AddValidationInjection(this IServiceCollection services)
        {
            services.AddTransient<IValidator<RegisterDto>, RegisterDtoValidation>();
            services.AddTransient<IValidator<LoginDto>, LoginDtoValidation>();

            services.AddTransient<IValidator<DemandTypeCreateDto>, DemandTypeCreateDtoValidation>();
            services.AddTransient<IValidator<DemandCreateDto>, DemandCreateDtoValidation>();
        }
    }
}