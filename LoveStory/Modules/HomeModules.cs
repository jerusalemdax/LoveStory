using System;
using Nancy;

public class HomeModules : NancyModule
{
	public HomeModules ()
	{
		Get ["/"] = paramters => {
			return View["index"];
		};
	}
}