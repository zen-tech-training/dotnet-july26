using FluentValidation;
using Ops.Application.DTOs.Product;
using Ops.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ops.Application.Validators.Product
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Password)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.Role)
                        .IsInEnum()
                        .WithMessage("Invalid role specified.");

            RuleFor(x => x.MobileNumber)
                .NotEmpty()
                .MaximumLength(15);

            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
