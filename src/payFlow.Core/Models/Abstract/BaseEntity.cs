namespace payFlow.Core.Models.Base
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public BaseEntity()
        {
        }
        public BaseEntity(string title)
        {
            Title = title;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
