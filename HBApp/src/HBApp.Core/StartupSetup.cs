using HBApp.Core.Constant;
using HBApp.Core.Decorator;
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
                    case OperationContants.CreateOrder:
                        return serviceProvider.GetService<CreateOrderExecutor>();
                    case OperationContants.CreateCampaign:
                        return serviceProvider.GetService<CreateCampaignExecutor>();
                    case OperationContants.GetCampaignInfo:
                        return serviceProvider.GetService<GetCampaignInfoExecutor>();
                    case OperationContants.GetProductInfo:
                        return serviceProvider.GetService<GetProductInfoExecutor>();
                    case OperationContants.IncreaseTime:
                        return serviceProvider.GetService<IncreaseTimeExecutor>();

                    default:
                        throw new NotSupportedException($"ExecutorResolver, key: {key}");
                }
            });
    }
}
