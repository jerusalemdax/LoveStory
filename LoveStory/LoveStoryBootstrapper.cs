using System;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using System.Collections.Generic;
using Nancy.Responses;

public class LoveStoryBootstrapper : DefaultNancyBootstrapper
{
    protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
    {
        base.ApplicationStartup(container, pipelines);

        Console.WriteLine("LoveStoryBootstrapper ApplicationStartup");

        pipelines.BeforeRequest += (ctx) =>
        {
			Console.WriteLine("Pipelines Before Request");
            var username = ctx.Request.Query.username;

            if (username.HasValue)
            {
//                ctx.CurrentUser = new DemoUserIdentity
//                {
//                    UserName = username.ToString(),
//                    Claims = BuildClaims(username.ToString())
//                };
            }

            return null;
        };

        pipelines.AfterRequest += (ctx) =>
        {
			Console.WriteLine("Pipelines After Request");
            if (ctx.Response.StatusCode == HttpStatusCode.Unauthorized)
            {
                ctx.Response = new RedirectResponse("/login?returnUrl=" + Uri.EscapeDataString(ctx.Request.Path));
            }
        };

		pipelines.OnError += (ctx, ex) =>
		{
			Console.WriteLine("Pipelines OnError Request");
			return null;
		};
    }

    private static IEnumerable<string> BuildClaims(string userName)
    {
        var claims = new List<string>();

        // Only bob can have access to SuperSecure
        if (String.Equals(userName, "bob", StringComparison.InvariantCultureIgnoreCase))
        {
            claims.Add("SuperSecure");
        }

        return claims;
    }
}