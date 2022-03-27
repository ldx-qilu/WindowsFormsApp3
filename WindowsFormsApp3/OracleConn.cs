using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Data;

namespace WindowsFormsApp3
{
    class OracleConn
    {
        public string connString = "Data Source=192.168.0.106/orcl;User ID=LVDX;PassWord=lvdx2020";
        public OracleConnection open_Conn_Oracle(string connString)
        {
            //string connString = "Data Source=192.168.0.106/orcl;User ID=LVDX;PassWord=lvdx2020";
            OracleConnection conn = new OracleConnection(connString);
            conn.Open();
            Console.WriteLine("连接成功");
            return conn;
        }
        public void close_Conn_Oracle(OracleConnection conn)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                Console.WriteLine("连接关闭");
            }

        }
        public OracleDataReader get_Table_Info(OracleConnection conn, string queryString)
        {
            OracleCommand myORACCommand = conn.CreateCommand();
            myORACCommand.CommandText = queryString;
            //conn.Open();
            OracleDataReader myDataReader = myORACCommand.ExecuteReader();
            myDataReader.Read();
            //Console.WriteLine("email: " + myDataReader["STUNAME"]);
            Console.WriteLine("读取成功");
            return myDataReader;
        }
        public OracleDataAdapter get_Table_Info1(OracleConnection conn, string queryString)
        {
            OracleCommand myORACCommand = conn.CreateCommand();
            myORACCommand.CommandText = queryString;
            //conn.Open();
            OracleDataAdapter myDataAdapter = new OracleDataAdapter(queryString,conn);
            
            //Console.WriteLine("email: " + myDataReader["STUNAME"]);
            Console.WriteLine("读取成功");
            return myDataAdapter;
        }
        public void close_DataReader(OracleDataReader myDataReader)
        {
            if (myDataReader.IsClosed)
            {

            }
            else
            {
                myDataReader.Close();
            }
        }

        public int up_Table_Info(OracleConnection conn, string queryString)
        {
            OracleCommand myORACCommand = conn.CreateCommand();
            myORACCommand.CommandText = queryString;
            int i = 0;
            try
            {
                i = myORACCommand.ExecuteNonQuery();
                Console.WriteLine("更新成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                //throw;
            }
            
            
            return i;
        }
    }
}
