﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace MikeGrayCodes.BuildingBlocks.Infrastructure
{
    public class SqlConnectionFactory : ISqlConnectionFactory, IDisposable
    {
        private readonly string connectionString;
        private IDbConnection connection;

        public SqlConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IDbConnection GetOpenConnection()
        {
            if (this.connection == null || this.connection.State != ConnectionState.Open)
            {
                this.connection = new SqlConnection(connectionString);
                this.connection.Open();
            }

            return this.connection;
        }

        public void Dispose()
        {
            if (this.connection != null && this.connection.State == ConnectionState.Open)
            {
                this.connection.Dispose();
            }
        }
    }
}