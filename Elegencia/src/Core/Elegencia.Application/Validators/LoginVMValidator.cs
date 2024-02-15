using Elegencia.Application.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.Validators
{
    public class LoginVMValidator:AbstractValidator<LoginVM>
    {
        private const int MinUsernameOrEmailLength = 4;
        private const int MaxUsernameOrEmailLength = 254;
        public LoginVMValidator()
        {
            RuleFor(r => r.UsernameOrEmail)
              .NotEmpty().WithMessage("Username can't be empty")
              .MinimumLength(MinUsernameOrEmailLength).WithMessage("Username or email length can't be less than 4 characters")
              .MaximumLength(MaxUsernameOrEmailLength).WithMessage("Username or email length can't be more than 254 characters");
        }
    }
}
