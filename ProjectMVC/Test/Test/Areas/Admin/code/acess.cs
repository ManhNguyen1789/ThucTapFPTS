using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Test.Areas.Admin.Models;

namespace Test.Areas.Admin.code
{
    public class acess : DbConnection
    {
       
        public int LoginAdmin( string username, string password)
        {
            int res = 0;
            ketnoiproc("accunt");
            cmd.Parameters.AddWithValue("@tk",username);
            cmd.Parameters.AddWithValue("@mk", password);
            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName = "@req";
            oblogin.SqlDbType = SqlDbType.Bit;
            oblogin.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(oblogin);
            _conn.Open();
            cmd.ExecuteNonQuery();
            res = Convert.ToInt32(oblogin.Value);
            return res;

        }
    }
}