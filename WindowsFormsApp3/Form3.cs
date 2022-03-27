using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Data.OleDb;

namespace WindowsFormsApp3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //本地调用
            //OracleConnection conn = this.open_Conn_Oracle();
            //string queryString;
            //queryString = "SELECT * FROM T_STU";
            //OracleDataReader myDataReader = get_table_Info(conn, queryString);

            //DataTable P_dt = myDataReader.GetSchemaTable();
            //dataGridView1.DataSource = P_dt;
            //close_DataReader(myDataReader);
            //close_Conn_Oracle(conn);

            //引入封装的Oracle连接类
            OracleConn oc = new OracleConn();            
            OracleConnection conn = oc.open_Conn_Oracle(oc.connString);
            string queryString;
            queryString = "insert into T_STU (STUID,STUNAME, STUSEX) values ( 4, '测试','女')";
            int count = oc.up_Table_Info(conn, queryString);

            queryString = "SELECT * FROM T_STU";       

            OracleDataAdapter adapter = oc.get_Table_Info1(conn, queryString);
            DataTable P_dt = new DataTable();
            adapter.Fill(P_dt);
            dataGridView1.DataSource = P_dt;
            oc.close_Conn_Oracle(conn);
            //OracleDataReader myDataReader = oc.get_Table_Info(conn, queryString);
            //DataTable P_dt = myDataReader.GetSchemaTable();
            //dataGridView1.DataSource = P_dt;
            //oc.close_DataReader(myDataReader);
            //oc.close_Conn_Oracle(conn);

        }
        //private OracleConnection open_Conn_Oracle()
        //{
        //    string connString = "Data Source=192.168.0.106/orcl;User ID=LVDX;PassWord=lvdx2020";
        //    OracleConnection conn = new OracleConnection(connString);
        //    conn.Open();
        //    Console.WriteLine("连接成功");
        //    return conn;
        //}
        //private void close_Conn_Oracle(OracleConnection conn)
        //{
        //    if (conn.State == ConnectionState.Open)
        //    {
        //        conn.Close();
        //        Console.WriteLine("连接关闭");
        //    }

        //}
        //private OracleDataReader get_table_Info(OracleConnection conn, string queryString)
        //{
        //    OracleCommand myORACCommand = conn.CreateCommand();
        //    myORACCommand.CommandText = queryString;
        //    conn.Open();
        //    OracleDataReader myDataReader = myORACCommand.ExecuteReader();
        //    myDataReader.Read();
        //    Console.WriteLine("email: " + myDataReader["STUNAME"]);
        //    Console.WriteLine("读取成功");
        //    return myDataReader;
        //}
        //private void close_DataReader(OracleDataReader myDataReader)
        //{
        //    if (myDataReader.IsClosed)
        //    {

        //    }
        //    else
        //    {
        //        myDataReader.Close();
        //    }
        //}

        //private void get_Oracle_Info()
        //{

        //    string connectionString;
        //    string queryString;

        //    connectionString = "Data Source=192.168.0.106/orcl;User ID=LVDX;PassWord=lvdx2020";

        //    queryString = "SELECT * FROM T_STU";

        //    OracleConnection myConnection = new OracleConnection(connectionString);

        //    OracleCommand myORACCommand = myConnection.CreateCommand();

        //    myORACCommand.CommandText = queryString;

        //    myConnection.Open();

        //    OracleDataReader myDataReader = myORACCommand.ExecuteReader();

        //    myDataReader.Read();

        //    Console.WriteLine("email: " + myDataReader["STUNAME"]);

        //    //DataTable P_dt = new DataTable();
        //    DataTable P_dt = myDataReader.GetSchemaTable();
        //    this.dataGridView1.DataSource = P_dt;
        //    Console.WriteLine("连接成功");

        //    myDataReader.Close();

        //    myConnection.Close();
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }
    }
}
