using System.Security.Cryptography;
using System.Text;

public class MD5Helper
{
	private static MD5 md5_provider = new MD5CryptoServiceProvider();
	public static string MD5(string content)
	{
		byte[] result = md5_provider.ComputeHash (Encoding.UTF8.GetBytes (content));
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < result.Length; i++)
		{
			sb.AppendFormat("{0:x2}", result[i]);
		}
		return sb.ToString();
	}
}

