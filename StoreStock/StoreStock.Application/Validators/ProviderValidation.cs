using FluentValidation;
using StoreStock.Domain.Entities;

namespace StoreStock.Application.Validators
{
    public class ProviderValidation : AbstractValidator<Provider>
    {
        public ProviderValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome deve ser preechido.")
                .Length(2, 50).WithMessage("O nome deve conter entre 2 a 50 caracteres.");

            RuleFor(x => x.SocialContract)
                .NotEmpty().WithMessage("A razão social deve ser preechida.")
                .Length(10, 300).WithMessage("A razão social deve conter entre 10 a 300 caracteres.");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("O CPF deve ser preechido.");


            RuleFor(x => x.Cnpj)
                .NotEmpty().WithMessage("O CNPJ deve ser preechido.");
        }
    }
}
