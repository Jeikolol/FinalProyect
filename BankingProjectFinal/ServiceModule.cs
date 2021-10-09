using Autofac;
using BankingProject.Infrastructure;
using BankingProject.Services;
using BankingProjectFinal.Services;

namespace BankingProjectFinal
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Service>().As<IService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SecurityService>().As<ISecurityService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TransferenciaService>().As<ITransferenciaService>()
                .InstancePerLifetimeScope();
        }
    }
}
