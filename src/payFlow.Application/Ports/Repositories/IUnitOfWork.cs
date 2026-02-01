namespace payFlow.Application.Ports.Repositories
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
