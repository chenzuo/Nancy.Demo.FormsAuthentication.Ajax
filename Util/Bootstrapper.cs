using Nancy.Authentication.Forms;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace Nancy.Demo
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);
            container.Register<IUserMapper, UserDatabase>();
        }

        protected override void RequestStartup(TinyIoCContainer requestContainer, IPipelines pipelines, NancyContext context)
        {
            var formsAuthConfiguration = new FormsAuthenticationConfiguration
            {
                RedirectUrl = "~/",
                UserMapper = requestContainer.Resolve<IUserMapper>(),
            };
            FormsAuthentication.Enable(pipelines, formsAuthConfiguration);
        }
    }
}