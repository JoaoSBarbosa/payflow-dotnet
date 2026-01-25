using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using payFlow.Infra.Data;

namespace payFlow.Infra.DependencyInjection
{
    public static class InfraModule
    {

        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PayFlowContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            //services.AddScoped<ITransactionRepository, TransactionRepository>();
            return services;

        }
    }
}
