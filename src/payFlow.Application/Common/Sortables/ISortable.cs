namespace payFlow.Application.Common.Sortables
{
    public interface ISortable<TOrderBy>
    {
        TOrderBy OrderBy { get; set; }
        bool Descending { get; set; }   
    }
}
