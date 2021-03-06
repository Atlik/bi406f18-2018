﻿using System;
using MySql.Data.MySqlClient;

namespace DietTracker
{
    class DatabaseConnect
    {
        private static MySqlConnection OpenDBConnection(string host, string user, string pwd, string db,string Ssl)
        {
            string connStr = String.Format("server={0};uid={1};pwd={2};database={3};SslMode={4};", host, user, pwd, db, Ssl);
            var conn = new MySqlConnection();
            conn.ConnectionString = connStr;
            return conn;
        }

        public static MySqlConnection OpenDefaultDBConnection()
        {
            return OpenDBConnection("localhost", "ApplicationAccess", "", "diettracker", "none");
        }
    }
}
