using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<UserForRegisterDto>
    {
        public UserValidator()
        {
            RuleFor(u=>u.FirstName).MinimumLength(3);
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.Email).Must(ValidMail).WithMessage("Geçersiz mail");
            RuleFor(u => u.Password).Must(ValidPassword).WithMessage("Şifre 1 büyük harf, 1 özel karakter dahil olmak üzere en az 8 karakterden oluşmalıdır!");
        }
        public static bool ValidPassword(string arg)
        {
            return Regex.IsMatch(arg, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$");
        }
        public static bool ValidMail(string arg)
        {
            return Regex.IsMatch(arg, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
           

        }
    }
}
