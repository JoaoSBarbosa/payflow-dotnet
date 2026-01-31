using Microsoft.Extensions.DependencyInjection;
using payFlow.Application.Categories.Interfaces;
using payFlow.Application.Categories.Services;

namespace payFlow.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}
