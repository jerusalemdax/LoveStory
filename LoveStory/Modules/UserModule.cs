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
			if(username == string.Empty || username.Length > 50)
			{
				return View["signup"];
			}
			if(!Regex.IsMatch(username, @"^[A-Za-z0-9]+$"))
			{
				return View["signup"];
			}
			string email = (string)this.Request.Form.Email;
			if(email == string.Empty || email.Length > 100)
			{
				return View["signup"];
			}
			//判断是否邮箱格式
			if(!Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
			{
				return View["signup"];
			}

			string nick_name = (string)this.Request.Form.NickName;
			if( nick_name == string.Empty || nick_name.Length > 100)
			{
				return View["signup"];
			}
			if(!Regex.IsMatch(nick_name, @"^[\u4E00-\u9FA5A-Za-z0-9_]+$"))
			{
				return View["signup"];
			}
			string password = (string)this.Request.Form.Password;
			string confirm_password = (string)this.Request.Form.Confirm_Password;
			if(password == string.Empty || password.Length > 20 || password.Length < 6)
			{
				return View["signup"];
			}
			if(password != confirm_password)
			{
				return View["signup"];
			}
			if(!Regex.IsMatch(password, @"^[a-zA-Z]\w{5,20}$"))
			{
				return View["signup"];
			}
			SimpleDataHelper.DB.Users.Insert(Name: username, Email: email, Nick_Name: nick_name, Password: password);
			return "注册成功";
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