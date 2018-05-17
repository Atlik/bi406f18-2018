﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DietTracker
{
    class DatabaseConnect
    {
        public static MySqlConnection OpenDBConnection(string host, string user, string pwd, string db)
        {
            string connStr = String.Format("server={0};uid={1};pwd={2};database={3};", host, user, pwd, db);
            var conn = new MySqlConnection();
            conn.ConnectionString = connStr;
            return conn;
        }

        public static MySqlConnection OpenDefaultDBConnection()
        {
            return OpenDBConnection("localhost", "ApplicationAccess", "", "diettracker");
        }
    }
}