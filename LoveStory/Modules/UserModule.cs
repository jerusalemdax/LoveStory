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
            return View["signup"];
        };

        Get["/signin"] = paramters =>
        {
            return View["/signin"];  
        };

        Post["/signin"] = paramters =>
        {
            string username = (string)this.Request.Form.Username;
            string password = (string)this.Request.Form.Password;
            return View["/signin"];
        };
    }
}