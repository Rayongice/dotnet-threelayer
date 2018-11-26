using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WALLE.TestProject3.DAL
{
    public class SqlHelper
    {
        private readonly static string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public static DataTable GetTable(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                if(conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                using (SqlDataAdapter apter = new SqlDataAdapter(sql, conn))
                {
                    apter.SelectCommand.CommandType = type;
                    if(pars != null)
                    {
                        apter.SelectCommand.Parameters.AddRange(pars);
                    }
                    DataTable da = new DataTable();
                    apter.Fill(da);
                    return da;
                }
            }
        }
        public static int ExecuteNonQuery(string sql, CommandType type, params SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = type;
                    if(pars !=null)
                    {
                        cmd.Parameters.AddRange(pars);
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
