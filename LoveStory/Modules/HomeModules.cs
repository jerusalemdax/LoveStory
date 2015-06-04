using System;
using Nancy;
using Simple.Data;

public class HomeModules : NancyModule
{
	public HomeModules ()
	{
		Get ["/"] = paramters => {
            var db = Database.OpenConnection("Server=127.0.0.1;Port=5432;Database=LoveStory;Integrated Security=true");
            //var user = db.Public.Users.FindByName("daniel");
            return "find user";// +user.Password;
		};
	}
}