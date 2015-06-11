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
	}
}