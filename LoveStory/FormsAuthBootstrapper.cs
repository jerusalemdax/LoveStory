using System;
using Nancy;
using Nancy.Authentication.Forms;

public class FormsAuthBootstrapper : DefaultNancyBootstrapper
{
    protected override void ConfigureRequestContainer(Nancy.TinyIoc.TinyIoCContainer container, NancyContext context)
    {
        base.ConfigureRequestContainer(container, context);
        container.Register<IUserMapper, UserDatabase>();
    }
}