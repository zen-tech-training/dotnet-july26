using FluentValidation;
using Ops.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ops.Application.Validators.Product
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .MaximumLength(500);

            RuleFor(x => x.Price)
                .GreaterThan(0);

            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.SKU)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
