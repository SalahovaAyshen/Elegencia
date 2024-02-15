using Elegencia.Application.ViewModels.Manage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.Validators.Manage.Chef
{
    public class UpdateChefVMValidator:AbstractValidator<UpdateChefVM>
    {
        private const int MinNameLength = 3;
        private const int MaxNameLength = 25;
        private const int MinSurnameLength = 3;
        private const int MaxSurnameLength = 25;
        public UpdateChefVMValidator()
        {
            RuleFor(r => r.Name)
            .NotEmpty().WithMessage("Name can't be empty")
            .Matches(@"^[a-zA-z\s]*$").WithMessage("Name must contain just letters")
            .MinimumLength(MinNameLength).WithMessage("Name length can't be less than 3 letters")
            .MaximumLength(MaxNameLength).WithMessage("Name length can't be more than 25 letters");

            RuleFor(r => r.Surname)
             .NotEmpty().WithMessage("Surname can't be empty")
             .Matches(@"^[a-zA-z\s]*$").WithMessage("Surname must contain just letters")
             .MinimumLength(MinSurnameLength).WithMessage("Surname length can't be less than 3 letters")
             .MaximumLength(MaxSurnameLength).WithMessage("Surname length can't be more than 25 letters");

            RuleFor(r => r.Info)
              .NotEmpty().WithMessage("Information about chef can't be empty");

            RuleFor(r => r.Instagram)
             .NotEmpty().WithMessage("Instagram link can't be empty");
            RuleFor(r => r.Facebook)
             .NotEmpty().WithMessage("Facebook link can't be empty");
            RuleFor(r => r.Linkedin)
             .NotEmpty().WithMessage("Linkedin link can't be empty");
        }
    }
}
