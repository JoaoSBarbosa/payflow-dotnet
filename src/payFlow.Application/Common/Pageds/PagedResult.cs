namespace payFlow.Application.Common.Pageds
{
    public class PagedResult<T>
    {

        public IReadOnlyList<T> Items { get; set; }
        public int TotalCount { get; }      //-----------> total de registro quem existem no banco
        public int Page { get; set; }      //------------> página atual solicitada
        public int PageSize { get; set; } //-------------> quantos itens vêm por página
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize); // quantas páginas existem no total




        public PagedResult(IReadOnlyList<T> items, int totalCount, int page, int pageSize)
        {
            Items = items;
            TotalCount = totalCount;
            Page = page;
            PageSize = pageSize;

        }
    }
}
