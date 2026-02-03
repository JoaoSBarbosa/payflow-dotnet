using payFlow.Application.Common.Request;

namespace payFlow.Application.Common.Pageds
{
    public abstract class PagedRequest: BaseRequest
    {

        public int Page { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value <= 0 ? 10 : Math.Min(value, 100);
        }

    }
}
