using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApp3
{
    class MySqlConn
    {
        public string constr = string.Format("server={0};user id = {1};pwd = 'lvdx2020';port = {2};database=mysql;pooling = false;", "localhost", "root", 3306);

        public MySqlConnection open_MySql(string constr)
        {
            MySqlConnection conn = new MySqlConnection(constr);
            try
            {
                conn.Open();
                Console.WriteLine("连接成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return conn;
        }
        public void close_SqlServer(MySqlConnection conn)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

        }

    }
}
