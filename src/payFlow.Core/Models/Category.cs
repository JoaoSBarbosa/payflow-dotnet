using payFlow.Core.Models.Base;
using payFlow.Core.Validations;

namespace payFlow.Core.Models
{
    public class Category: BaseEntity
    {
        public string? Description { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UserId { get; set; } = string.Empty;

        private readonly List<Transaction> _transactions = new();
        public IReadOnlyCollection<Transaction> Transactions => _transactions;
        public Category(string title, string userId, string? description = null) : base(title)
        {
            Validation(title, userId, description);
            UserId = userId;
            Description = description;
        }
        public Category() : base()
        {

        }

        private static void Validation(string title, string userId, string? description)
        {
            CategoryDomainValidation.NotNullOrEmpty(title, "Titulo");
            CategoryDomainValidation.MaxLength(title!, 100, "Titulo");
            CategoryDomainValidation.MinLength(title!, 3, "Titulo");

            CategoryDomainValidation.NotNullOrEmpty(userId, "E-mail de usuário");
            CategoryDomainValidation.MaxLength(userId, 200, "E-mail de usuário");
            CategoryDomainValidation.MinLength(userId, 6, "E-mail de usuário");

            if (!string.IsNullOrWhiteSpace(description))
            {
                CategoryDomainValidation.MaxLength(description!, 255, "Descrição");
                CategoryDomainValidation.MinLength(description!, 3, "Descrição");

            }
            CategoryDomainValidation.NotNullOrEmpty(title, "Titulo");

        }
    }
}
