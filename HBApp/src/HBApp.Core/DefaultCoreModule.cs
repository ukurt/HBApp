using Autofac;
using HBApp.Core.Decorator;
using HBApp.Core.Interfaces;
using HBApp.Core.Services;

namespace HBApp.Core
{
    public class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<OrderService>().As<IOrderService>().InstancePerLifetimeScope();
            builder.RegisterType<CampaignService>().As<ICampaignService>().InstancePerLifetimeScope();
            builder.RegisterType<CampaignService>().As<ICampaignService>().InstancePerLifetimeScope();
            builder.RegisterType<CreateProductExecutor>();
            builder.RegisterType<CreateCampaignExecutor>();
            builder.RegisterType<CreateOrderExecutor>();
            builder.RegisterType<GetCampaignInfoExecutor>();
            builder.RegisterType<GetProductInfoExecutor>();
            builder.RegisterType<IncreaseTimeExecutor>();

            builder.RegisterType<ParseService>().Named<IParseService>("handler");
            builder.RegisterDecorator<IParseService>((c, inner) => new ParseServiceWithExecution(inner, c.Resolve<ExecutorResolver>()), fromKey: "handler");

        }
    }
}
