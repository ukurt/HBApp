using HBApp.Core.Constant;
using HBApp.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HBApp.Core
{
    public static class StartupSetup
    {
        public static void AddResolver(this IServiceCollection services) =>

            services.AddTransient<ExecutorResolver>(serviceProvider => key =>
            {
                switch (key.ToString())
                {
                    case OperationContants.CreateProduct:
                        return serviceProvider.GetService<CreateProductExecutor>();
                    
                    default:
                        throw new NotSupportedException($"ExecutorResolver, key: {key}");
                }
            });
    }
}
