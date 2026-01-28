using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace payFlow.Infra.Data.Context;

public class PayFlowContextFactory: IDesignTimeDbContextFactory<PayFlowContext>
{
    public PayFlowContext CreateDbContext(string[] args)
    {
       var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
       
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile($"appsettings.{env}.json", optional: true)
            .AddUserSecrets<PayFlowContextFactory>(optional: true)
            .AddEnvironmentVariables()
            .Build();

        var connectionString = config.GetConnectionString("LinuxConnection");
        if ( string.IsNullOrWhiteSpace(connectionString)) throw new InvalidOperationException("ConnectionString 'LinuxConnection' não configurada.");

        var optionsBuilder = new DbContextOptionsBuilder<PayFlowContext>();
        optionsBuilder.UseSqlServer(connectionString);
        return new PayFlowContext(optionsBuilder.Options);
    }
}