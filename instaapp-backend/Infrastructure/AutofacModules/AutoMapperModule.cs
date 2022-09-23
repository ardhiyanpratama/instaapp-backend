using Autofac;
using AutoMapper;
using HashidsNet;

namespace instaapp_backend.Infrastructure.AutofacModules
{
    public class AutoMapperModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                var assembliesTypes = ThisAssembly.GetTypes()
                    .Where(t => typeof(Profile).IsAssignableFrom(t) && t.IsPublic && !t.IsAbstract);

                var hashidsService = ctx.Resolve<IHashids>() ?? throw new ArgumentNullException(nameof(IHashids));

                var autoMapperProfiles = assembliesTypes
                    .Select(p => (Profile)Activator.CreateInstance(p, hashidsService)).ToList();

                foreach (var profile in autoMapperProfiles)
                {
                    cfg.AddProfile(profile);
                }
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}
