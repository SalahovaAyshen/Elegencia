using Elegencia.Application.ViewModels.Manage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.Validators.Manage.Salad
{
    public class CreateSaladVMValidator:AbstractValidator<CreateSaladVM>
    {
        private const int MinNameLength = 2;
        private const int MaxNameLength = 100;
        public CreateSaladVMValidator()
        {
            RuleFor(r => r.Name)
            .NotEmpty().WithMessage("Name can't be empty")
            .MinimumLength(MinNameLength).WithMessage("Name length can't be less than 2 letters")
            .MaximumLength(MaxNameLength).WithMessage("Name length can't be more than 100 letters");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price can't be empty").Must(CheckPrice);
        }
        private bool CheckPrice(decimal price)
        {
            if (price >= 1 && price < 999999.99m)
            {
                return true;
            }
            return false;
        }
    }
}
