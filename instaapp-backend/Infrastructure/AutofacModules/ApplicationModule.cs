using Autofac;
using HashidsNet;

namespace instaapp_backend.Infrastructure.AutofacModules
{
    public class ApplicationModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new Hashids("In5t4aPPS", 12)).As<IHashids>();
        }
    }
}
