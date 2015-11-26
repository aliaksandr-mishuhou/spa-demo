using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Crap.Data.Providers;
using Crap.Data.Providers.EF;

namespace Crap.UI.App_Start
{
    public class AutofacConfig
    {
        public static IContainer Container;
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, Register(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer Register(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterGeneric(typeof(EfRepository<>))
                   .As(typeof(IRepository<>))
                   .InstancePerRequest();

            Container = builder.Build();
            return Container;
        }

    }
}