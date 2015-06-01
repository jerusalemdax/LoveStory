using System;
using Nancy;

public class UserModule : NancyModule
{
    public UserModule()
    {
        Get["/signup"] = paramters =>
        {
            return View["signup"];
        };

        Post["/signup"] = paramters =>
        {
            return View["index"];
        };
    }
}