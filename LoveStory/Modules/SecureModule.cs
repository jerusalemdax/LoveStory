using System;
using Nancy;
using Nancy.Security;

public class SecureModule : NancyModule
{
    public SecureModule() : base("/secure")
    {
        this.RequiresAuthentication();

        Get["/"] = x =>
        {
            return "secure";
        };
    }
}