using System;
using Nancy;

public class HomeModules : NancyModule
{
	public HomeModules ()
	{
		Get ["/"] = paramters => {
			return "This is our Love Story";
		};
	}
}