using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using payFlow.Application.Features.Categories.Ports;
using payFlow.Application.Ports.Repositories;
using payFlow.Infra.Data.Context;
using payFlow.Infra.Repositories;
using payFlow.Infra.Repositories.UnitOfWork;

namespace payFlow.Infra.DependencyInjection
{
    public static class InfraModule
    {

        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PayFlowContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;

        }
    }
}
