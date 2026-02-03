using payFlow.Application.Common.Pageds;
using payFlow.Application.Common.Sortables;

namespace payFlow.Application.Features.Categories.Query
{
    public class CategoryFilter: PagedRequest, ISortable<ECategoryOrderBy>
    {
        public long? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public ECategoryOrderBy OrderBy { get; set; } = ECategoryOrderBy.Id;
        public bool Descending { get; set; } = false;
    }
}
