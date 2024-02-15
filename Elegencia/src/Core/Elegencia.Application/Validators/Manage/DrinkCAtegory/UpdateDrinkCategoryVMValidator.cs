﻿using Elegencia.Application.ViewModels.Manage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.Validators.Manage.DrinkCAtegory
{
    public class UpdateDrinkCategoryVMValidator:AbstractValidator<UpdateDrinkCategoryVM>
    {
        private const int MinNameLength = 2;
        private const int MaxNameLength = 50;
        public UpdateDrinkCategoryVMValidator()
        {
            RuleFor(r => r.Name)
            .NotEmpty().WithMessage("Name can't be empty")
            .MinimumLength(MinNameLength).WithMessage("Name length can't be less than 2 letters")
            .MaximumLength(MaxNameLength).WithMessage("Name length can't be more than 50 letters");
        }
    }
}
