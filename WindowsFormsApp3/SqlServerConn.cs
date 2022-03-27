using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApp3
{
    class SqlServerConn
    {
        public string constr = string.Format("server={0};uid = {1};pwd = 'sa2012';;database=Datatest", "localhost", "sa");
        public SqlConnection open_SqlServer(string constr)
        {
            SqlConnection conn = new SqlConnection(constr);
            try
            {
                conn.Open();
                Console.WriteLine("连接成功") ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return conn;
        }
        public void close_SqlServer(SqlConnection conn)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            
        }
    }

    
}
