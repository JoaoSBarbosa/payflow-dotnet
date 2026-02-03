using FluentValidation;
using payFlow.Application.Features.Transactions.DTOs.Requests;

namespace payFlow.Application.Features.Transactions.Validators
{
    public class CreateTransactionsValidator: AbstractValidator<TransactionCreate>
    {
        public CreateTransactionsValidator()
        {
            RuleFor( t => t.Title)
                .NotEmpty().WithMessage("Titulo da transação é obrigatório.")
                .MaximumLength(100).WithMessage("O título não deve exceder 100 caracteres.");

            RuleFor( t => t.Amount)
                .GreaterThan(0).WithMessage("O valor da transação deve ser maior que zero.");

            RuleFor( t => t.CategoryId)
                .GreaterThan(0).WithMessage("A categoria da transação é obrigatória.");

            RuleFor( t => t.Type)
                .IsInEnum().WithMessage("O tipo de transação é inválido.");
        }

       
    }
}
