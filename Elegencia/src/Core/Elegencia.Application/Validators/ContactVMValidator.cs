using Elegencia.Application.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.Validators
{
    public class ContactVMValidator:AbstractValidator<ContactVM>
    {
        private const int MinNameLength = 3;
        private const int MaxNameLength = 25;
        public ContactVMValidator()
        {
            RuleFor(r => r.Name)
              .NotEmpty().WithMessage("Name can't be empty")
              .Matches(@"^[a-zA-z\s]*$").WithMessage("Name must contain just letters")
              .MinimumLength(MinNameLength).WithMessage("Name length can't be less than 3 letters")
              .MaximumLength(MaxNameLength).WithMessage("Name length can't be more than 25 letters");

            RuleFor(r => r.Email)
               .NotEmpty().WithMessage("Email can't be empty");
            RuleFor(r => r.CommentText)
               .NotEmpty().WithMessage("Text can't be empty");
        }
    }
}
