using System.Collections.Generic;
using Nancy.Security;
public class User : IUserIdentity
{
    public string UserName { get; set; }

    public IEnumerable<string> Claims { get; set;}
}