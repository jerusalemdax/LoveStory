using System;
using Nancy;
using Simple.Data;
using System.Threading.Tasks;
using System.Net;

public class HomeModules : NancyModule
{
	public HomeModules ()
	{
		Get ["/"] = parameters =>
		{
			StaticConfiguration.DisableErrorTraces = false;
            var db = Database.OpenConnection("Server=localhost;Port=3306;Database=LoveStory;Uid=username;Pwd=password");
            var user = db.Users.FindByName("daniel");
			return "find user" + user.Password;
		};
	}
}