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
		Get ["/"] = parameters =>
		{
			return View["index"];
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