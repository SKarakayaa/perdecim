using System;
using System.Linq;
using Entities.DTO.Auth;
using FluentValidation;

namespace Business.Validations.Auth
{
    public class RegisterDtoValidation : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu Alan Zorunludur !");
            RuleFor(x => x.Name).NotNull().WithMessage("Bu Alan Zorunludur !");
            RuleFor(x => x.Name).Must(CheckContainsNumber).WithMessage("İsim Alanı Sayısal İfade Yer Alamaz !");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("Bu Alan Zorunludur !");
            RuleFor(x => x.Surname).NotNull().WithMessage("Bu Alan Zorunludur !");
            RuleFor(x => x.Surname).Must(CheckContainsNumber).WithMessage("Soyisim Alanı Sayısal İfade Yer Alamaz !");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Bu Alan Zorunludur !");
            RuleFor(x => x.PhoneNumber).NotNull().WithMessage("Bu Alan Zorunludur !");
            RuleFor(x => x.PhoneNumber).Length(10).Must(x => decimal.TryParse(x, out decimal _)).WithMessage("Telefon Numarası 10 Sayısal Karakterden oluşmalı !");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Bu Alan Zorunludur !");
            RuleFor(x => x.Email).NotNull().WithMessage("Bu Alan Zorunludur !");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email Formatında Değil !");

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
        private bool CheckContainsNumber(string arg)
        {
            if (!String.IsNullOrEmpty(arg) && arg.Any(char.IsDigit))
                return false;
            return true;
        }
    }
}