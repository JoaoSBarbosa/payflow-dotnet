using payFlow.Application.Ports.Repositories;
using payFlow.Infra.Data.Context;

namespace payFlow.Infra.Repositories.UnitOfWork
{
    internal class UnitOfWork(PayFlowContext context) : IUnitOfWork
    {
        private readonly PayFlowContext _context = context;
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
