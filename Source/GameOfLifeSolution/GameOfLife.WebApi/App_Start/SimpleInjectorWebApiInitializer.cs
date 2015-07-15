[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(GameOfLife.WebApi.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace GameOfLife.WebApi.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;

    public class SimpleInjectorWebApiInitializer
    {
        public static void Initialize()
        {
            var container = new Container();

            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            //container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            // For instance:
            // container.RegisterWebApiRequest<IUserRepository, SqlUserRepository>();
        }
    }
}