using System;
using System.Text.RegularExpressions;
using Nancy;

public class UserModule : NancyModule
{
    public UserModule()
    {
        Get["/signup"] = paramters =>
        {
            return View["signup"];
        };

        Post["/signup"] = paramters =>
        {
			string username = (string)this.Request.Form.Username;
			if(username == string.Empty || username.Length > 50 || username.Length < 6)
			{
				return "username is empty or too long or too short";
			}

			if(SimpleDataHelper.DB.Users.Exists(SimpleDataHelper.DB.Users.Name == username))
			{
				return "username has beed register";
			}

			if(!Regex.IsMatch(username, @"^[A-Za-z0-9]+$"))
			{
				return "username has invalid character";
			}
			string email = (string)this.Request.Form.Email;
			if(email == string.Empty || email.Length > 100)
			{
				return "email is empty or too long";
			}
			//判断是否邮箱格式
			if(!Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
			{
				return "email format error";
			}

			if(SimpleDataHelper.DB.Users.Exists(SimpleDataHelper.DB.Users.Email == email))
			{
				return "email has beed register";
			}

			string nick_name = (string)this.Request.Form.NickName;
			if( nick_name == string.Empty || nick_name.Length > 100 || nick_name.Length < 3)
			{
				return "nickname is empty or too long or too short";
			}
			if(!Regex.IsMatch(nick_name, @"^[\u4E00-\u9FA5A-Za-z0-9_]+$"))
			{
				return "nickname has invalid character";
			}

			if(SimpleDataHelper.DB.Users.Exists(SimpleDataHelper.DB.Users.Nick_Name == nick_name))
			{
				return "nickname has beed used";
			}

			string password = (string)this.Request.Form.Password;
			string confirm_password = (string)this.Request.Form.Confirm_Password;
			if(password == string.Empty || password.Length > 20 || password.Length < 6)
			{
				return "password is empty or less than 6 or larger than 20";
			}
			if(password != confirm_password)
			{
				return "two password not the same";
			}
			if(!Regex.IsMatch(password, @"^[a-zA-Z]\w{5,20}$"))
			{
				return "password format error, must start with character and contains number";
			}
			SimpleDataHelper.DB.Users.Insert(Name: username, Email: email, Nick_Name: nick_name, Password: password, Avater:"", Role:1, Guid: Guid.NewGuid());
			return "sign up success";
        };

        Get["/signin"] = paramters =>
        {
            return View["/signin"];  
        };

        Post["/signin"] = paramters =>
        {
            return View["/signin"];
        };
    }
}