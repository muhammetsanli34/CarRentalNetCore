using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.CarName).MinimumLength(2);
            RuleFor(c => c.ModelYear).GreaterThanOrEqualTo(2000);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(100).When(c => c.BrandId == 1);
            RuleFor(c => c.Description.Length).GreaterThanOrEqualTo(5);
        }
    }
}
