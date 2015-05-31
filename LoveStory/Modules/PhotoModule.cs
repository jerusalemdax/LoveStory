using System;
using Nancy;

public class PhotoModule : NancyModule
{
	public PhotoModule () : base("/photo")
	{
		Get ["/{slug}"] = paramters => {
			return string.Format("photho :" + paramters.slug);
		};
	}
}