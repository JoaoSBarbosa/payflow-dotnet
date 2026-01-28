using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace payFlow.Infra.Data;

public class PayFlowContextFactory: IDesignTimeDbContextFactory<PayFlowContext>
{
    public PayFlowContext CreateDbContext(string[] args)
    {
       
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<PayFlowContext>();
        optionsBuilder.UseSqlServer(config.GetConnectionString("LinuxConnection"));
        return new PayFlowContext(optionsBuilder.Options);
    }
}