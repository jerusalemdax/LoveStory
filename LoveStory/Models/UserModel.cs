using System;

public class UserModel
{
    public string Username { get; set; }
    public string Password { get; set; }

    public UserModel(string username, string password)
    {
        this.Username = username;
        this.Password = password;
    }

}