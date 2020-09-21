using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TaskList
{
    public static class Helper
    {
        public static IDbConnection Conn()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionToSql"].ConnectionString);

        }
    }
}
