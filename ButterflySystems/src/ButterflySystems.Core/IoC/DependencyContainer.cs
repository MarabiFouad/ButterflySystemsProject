using ButterflySystems.Core.Services;
using ButterflySystems.Core.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace ButterflySystems.Core.IoC
{
    public static class DependencyContainer
    {
        public static void InjectDependencies(this IServiceCollection services)
        {
            services.AddScoped<AddOperator>();
            services.AddScoped<SubtractOperator>();
            services.AddScoped<MultiplyOperator>();
            services.AddScoped<DivideOperator>();
            services.AddScoped<IMathStrategy, MathStrategy>();
            services.AddScoped<IMathStrategyFactory, MathStrategyFactory>();
            services.AddScoped(provider =>
            {
                var factory = (IMathStrategyFactory)provider.GetService(typeof(IMathStrategyFactory));
                return factory.Create();
            });

            services.AddScoped<ICalculatorService, CalculatorService>();
        }
    }
}
