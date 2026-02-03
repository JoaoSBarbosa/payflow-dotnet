using FluentValidation;
using payFlow.Application.Features.Categories.Requests;

namespace payFlow.Application.Features.Categories.Validators
{
    public class CreateCategoryValidator:AbstractValidator<CreateCategory>
    {

        public CreateCategoryValidator()
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("O título da categoria é obrigatório.")
                .MinimumLength(3).WithMessage("O título da categoria deve ter pelo menos 3 caracteres.")
                .MaximumLength(100).WithMessage("O título da categoria não deve exceder 100 caracteres.");


            RuleFor( c => c.Description)
                .MaximumLength(250).WithMessage("A descrição da categoria não deve exceder 250 caracteres.");

            RuleFor( c => c.UserId)
                .NotEmpty().WithMessage("O ID do usuário é obrigatório.")
                .MaximumLength(200).WithMessage("O e-mail do usuário não deve exceder 200 caracteres.");


        }
    }
}
