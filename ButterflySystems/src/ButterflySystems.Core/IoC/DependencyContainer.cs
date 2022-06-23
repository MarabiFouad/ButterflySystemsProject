using ButterflySystems.Core.Services;
using ButterflySystems.Core.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace ButterflySystems.Core.IoC
{
    public static class DependencyContainer
    {
        public static void InjectDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICalculatorService, CalculatorService>();
        }
    }
}
