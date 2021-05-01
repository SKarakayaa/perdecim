using Business.Validations.Address;
using Business.Validations.Auth;
using Business.Validations.Cart;
using Business.Validations.Demands;
using Business.Validations.Profile;
using Entities.DTO.Address;
using Entities.DTO.Auth;
using Entities.DTO.Cart;
using Entities.DTO.Demand;
using Entities.DTO.Profile;
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

            services.AddTransient<IValidator<UserAddressCreateUpdateDTO>, UserAddressCreateUpdateDtoValidation>();
            services.AddTransient<IValidator<ChangePasswordDTO>, ChangePasswordDtoValidation>();

            services.AddTransient<IValidator<CreateOrderDto>, CreateOrderDtoValidation>();
        }
    }
}