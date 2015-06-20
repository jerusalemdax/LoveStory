using System;
using Nancy.Authentication.Forms;
using Simple.Data;
using Nancy.Security;
using Nancy;

public class UserDatabase : IUserMapper
{
    public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
    {
		Console.WriteLine ("UserDatabase GetUserFromIdentifier");
		var userRecord = SimpleDataHelper.DB.Users.FindByGuid (identifier.ToString());
		return userRecord == null? null : new UserIdentity {UserName = userRecord.Name};
    }

    public static Guid? ValidateUser(string username, string password)
    {
		Console.WriteLine ("UserDatabase ValidateUser");
		var userRecord = SimpleDataHelper.DB.Users.FindByNameAndPassword (username, MD5Helper.MD5(password));
		if (userRecord == null)
		{
			return null;
		}
		return new Guid(userRecord.Guid);
    }
}