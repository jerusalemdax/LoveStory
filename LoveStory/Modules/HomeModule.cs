using System;
using Nancy;
using Simple.Data;
using System.Threading.Tasks;
using System.Net;
using Nancy.Security;

public class HomeModules : NancyModule
{
	public HomeModules ()
	{
		this.RequiresAuthentication();

		Get ["/"] = parameters =>
		{
			var model = new UserModel(this.Context.CurrentUser.UserName);
			return View["index", model];
		};

		Before += ctx => {
			Console.WriteLine ("Before Home Page");
			return null;
		};

		After += ctx => {
			Console.WriteLine ("After Home Page");
		};
	}
}