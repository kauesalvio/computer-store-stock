using FluentValidation;
using StoreStock.Domain.Entities;

namespace StoreStock.Application.Validators
{
    class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome deve ser preechido.")
                .Length(3, 50).WithMessage("O nome deve conter entre 3 a 50 caracteres.");

            RuleFor(x => x.Description)
                .MaximumLength(300).WithMessage("A descrição deve conter no máximo 300 caracteres.");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("O preço deve ser preechido.");

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("A categoria deve ser preechida.")
                .Length(3, 30).WithMessage("A categoria deve conter entre 3 a 30 caracteres.");
        }
    }
}
