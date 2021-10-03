using Autofac;
using HBApp.Core;
using HBApp.Infrastructure.Data;
using HBApp.SharedKernel.Interfaces;
using MediatR;
using MediatR.Pipeline;
using System.Collections.Generic;
using System.Reflection;
using Module = Autofac.Module;

namespace HBApp.Infrastructure
{
    public class DefaultInfrastructureModule : Module
    {
        private readonly bool _isDevelopment = false;
        public DefaultInfrastructureModule(bool isDevelopment, Assembly callingAssembly = null)
        {
            _isDevelopment = isDevelopment;
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (_isDevelopment)
            {
                RegisterDevelopmentOnlyDependencies(builder);
            }
            else
            {
                RegisterProductionOnlyDependencies(builder);
            }
            RegisterCommonDependencies(builder);
        }

        private void RegisterCommonDependencies(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EfRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();
        }

        private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
        {
            // TODO: Add development only services
        }

        private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
        {
            // TODO: Add production only services
        }

    }
}
