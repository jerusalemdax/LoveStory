using System;
using Simple.Data;

public class SimpleDataHelper
{
    private static dynamic db;
    public static dynamic DB
    {
        get
        {
            if (db == null)
            {
                db = Database.OpenConnection("Server=localhost;Port=3306;Database=LoveStory;Uid=username;Pwd=password");
            }
            return db;
        }
    }
}