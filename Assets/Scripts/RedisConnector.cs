using System;
using StackExchange.Redis;

public class RedisConnector
{
    private static ConnectionMultiplexer connection;

    public static IDatabase Connection
    {
        get
        {
            if (connection == null || !connection.IsConnected)
            {
                connection = ConnectionMultiplexer.Connect("localhost");
            }
            return connection.GetDatabase();
        }
    }
}
