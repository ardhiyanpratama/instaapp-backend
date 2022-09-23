using Autofac;
using instaapp_backend.Core.IConfiguration;
using instaapp_backend.Data;

namespace instaapp_backend.Infrastructure.AutofacModules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Other Lifetime
            // Transient
            //builder.RegisterType<OneTimePassword>().As<IOneTimePassword>()
            //    .InstancePerDependency();

            //// Scoped
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
                .InstancePerLifetimeScope();


            //// Singleton
            //builder.RegisterType<EmployeeService>().As<IEmployeeService>()
            //    .SingleInstance();

        }
    }
}
