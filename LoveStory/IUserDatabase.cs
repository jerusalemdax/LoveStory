using System;

public interface IUserDatabase
{
    Guid? ValidateUser(string username, string password);
}