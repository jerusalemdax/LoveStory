using System;
using Nancy;
using Simple.Data;

public class HomeModules : NancyModule
{
	public HomeModules ()
	{
		Get ["/"] = paramters => {
			StaticConfiguration.DisableErrorTraces = false;
            var db = Database.OpenConnection("Server=localhost;Port=3306;Database=LoveStory;Uid=username;Pwd=password");
            var user = db.Users.FindByName("daniel");
			return "find user" + user.Password;
		};
	}
}