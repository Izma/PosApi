﻿using MySql.Data.MySqlClient;

namespace Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string connectionString;

        public ConnectionFactory(string connection)
        {
            connectionString = connection;
        }

        public MySqlConnection Connection => new MySqlConnection(connectionString);
    }
}
