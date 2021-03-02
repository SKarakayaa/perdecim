using System;
using Entities.DTO.Auth;
using FluentValidation;

namespace Business.Validations.Auth
{
    public class LoginDtoValidation : AbstractValidator<LoginDto>
    {
        public LoginDtoValidation()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Bu Alan Zorunludur !");
            RuleFor(x => x.UserName).NotNull().WithMessage("Bu Alan Zorunludur !");
            RuleFor(x => x.UserName).Must(CheckFirstCharacterIsNumber).WithMessage("Kullanıcı Adı Sayı İle Başlayamaz");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Bu Alan Zorunludur !");
            RuleFor(x => x.Password).NotNull().WithMessage("Bu Alan Zorunludur !");
            RuleFor(x => x.Password).MinimumLength(5).WithMessage("Şifre En Az 5 Karakterden Oluşmalı !");
        }
        private bool CheckFirstCharacterIsNumber(string arg)
        {
            if (!String.IsNullOrEmpty(arg) && int.TryParse(arg[0].ToString(), out int _))
                return false;
            return true;
        }
    }
}