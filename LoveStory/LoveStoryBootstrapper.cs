using System;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using System.Collections.Generic;
using Nancy.Responses;
using Nancy.Authentication.Forms;

public class LoveStoryBootstrapper : DefaultNancyBootstrapper
{
    protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
    {
        base.ApplicationStartup(container, pipelines);

        Console.WriteLine("LoveStoryBootstrapper ApplicationStartup");
		StaticConfiguration.DisableErrorTraces = false;

        pipelines.BeforeRequest += (ctx) =>
        {
			Console.WriteLine("Pipelines Before Request");
            return null;
        };

        pipelines.AfterRequest += (ctx) =>
        {
			Console.WriteLine("Pipelines After Request");
        };

		pipelines.OnError += (ctx, ex) =>
		{
			Console.WriteLine("Pipelines OnError Request");
			return null;
		};
    }

	protected override void ConfigureRequestContainer (TinyIoCContainer container, NancyContext context)
	{
		Console.WriteLine("BootStrapper Configure Request Container");
		base.ConfigureRequestContainer (container, context);

		container.Register<IUserMapper, UserDatabase> ();
	}

	protected override void RequestStartup (TinyIoCContainer container, IPipelines pipelines, NancyContext context)
	{
		Console.WriteLine("BootStrapper Request Startup");
		base.RequestStartup (container, pipelines, context);

		var formsAuthConfiguration = new FormsAuthenticationConfiguration ()
		{
			RedirectUrl = "~/signin",
			UserMapper = container.Resolve<IUserMapper>(),				
		};
		FormsAuthentication.Enable (pipelines, formsAuthConfiguration);
	}
}