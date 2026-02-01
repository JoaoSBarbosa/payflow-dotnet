using Microsoft.EntityFrameworkCore;
using payFlow.Infra.Data.Context;

namespace payFlow.IntegrationTests.Common
{
    public abstract class IntegrationTestBase
    {
        protected PayFlowContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<PayFlowContext>().UseSqlite("DataSource=:memory:").Options;
            var context = new PayFlowContext(options);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();
            return context;
        }
    }
}
