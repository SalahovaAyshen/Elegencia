using Elegencia.Application.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.Validators
{
    public class RegisterVMValidator:AbstractValidator<RegisterVM>
    {
        private const int MaxUsernameLength = 32;
        private const int MaxEmailLength = 254;
        private const int MinPasswordLength = 8;
        private const int MinUsernameLength = 4;
        private const int MinNameOrSurnameLength = 3;
        private const int MaxNameLength = 25;
        private const int MaxSurnameLength = 30;
        public RegisterVMValidator()
        {
            RuleFor(r => r.Name)
               .NotEmpty().WithMessage("Name can't be empty")
               .Matches(@"^[a-zA-z\s]*$").WithMessage("Name must contain just letters")
               .MinimumLength(MinNameOrSurnameLength).WithMessage("Name length can't be less than 3 letters")
               .MaximumLength(MaxNameLength).WithMessage("Name length can't be more than 25 letters");

            RuleFor(r => r.Surname)
               .NotEmpty().WithMessage("Surname can't be empty")
               .Matches(@"^[a-zA-z\s]*$").WithMessage("Surname must contain just letters")
               .MinimumLength(MinNameOrSurnameLength).WithMessage("Surname length can't be less than 3 letters")
               .MaximumLength(MaxSurnameLength).WithMessage("Surname length can't be more than 30 letters");

            RuleFor(r => r.Username)
               .NotEmpty().WithMessage("Username can't be empty")
               .MinimumLength(MinUsernameLength).WithMessage("Username length can't be less than 4 characters")
               .MaximumLength(MaxUsernameLength).WithMessage("Username length can't be more than 254 characters");

            RuleFor(r => r.Email)
                .NotEmpty().WithMessage("Email length can't be empty")
                .Matches(@"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])*$").WithMessage("Wrong format")
                .MaximumLength(MaxEmailLength).WithMessage("Email length can't be more than 254");
            RuleFor(r => r.Password)
                .NotEmpty().WithMessage("Password can't be empty")
                .MinimumLength(MinPasswordLength).WithMessage("Password length can't be less than 8");
           
            RuleFor(r => r).Must(r => r.ConfirmPassword == r.Password);
        }
    }
}
