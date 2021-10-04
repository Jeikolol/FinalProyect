using Autofac;
using BankingProject.Infrastructure;
using BankingProject.Services;

namespace BankingProject.Data
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Service>().As<IService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SecurityService>().As<ISecurityService>()
                .InstancePerLifetimeScope();
        }
    }
}
