using System;
using Nancy.Authentication.Forms;
using Simple.Data;
using Nancy.Security;
using Nancy;

public class UserDatabase : IUserMapper, IUserDatabase
{
    public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
    {
        return null;
    }

    public Guid? ValidateUser(string username, string password)
    {
        return null;
    }
}