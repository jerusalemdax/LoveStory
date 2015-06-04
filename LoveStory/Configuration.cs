using System;

public class Configuration
{
    Configuration()
    {
        ConnectionString = @"Server=localhost;Port=3306;Database=test;Uid=root;Pwd=password";
        Server = "localhost";
        Port = "3306";
        Database = "test";
        User = "root";
        Password = "password";
        EncryptionKey = "EncryptionKey";
        HmacKey = "HmacKey";
        Password = "password";
    }

    public static string ConnectionString { get; set; }

    public static string EncryptionKey { get; set; }

    public static string HmacKey { get; set; }

    public static string Password { get; set; }

    public static string Server { get; set; }

    public static string Port { get; set; }

    public static string Database { get; set; }

    public static string User { get; set; }
}