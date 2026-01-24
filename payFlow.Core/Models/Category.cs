using payFlow.Core.Models.Base;

namespace payFlow.Core.Models
{
    public class Category: BaseEntity
    {
        public string? Description { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UserId { get; set; } = string.Empty;

        public Category(string title, string userId, string? description = null) : base(title)
        {
            UserId = userId;
            Description = description;
        }
        public Category() : base()
        {

        }
    }
}
