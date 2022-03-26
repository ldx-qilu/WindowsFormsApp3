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
            ////string connString = "User ID=LVDX;Password=lvdx2020;Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.0.106)(PORT = 1521))) (CONNECT_DATA = (SERVICE_NAME = RACE)))";
            ////OracleConnection conn = new OracleConnection(connString);
            //string connString = "Provider=OraOLEDB.Oracle.1;User ID=IFSAPP;Password=IFSAPP;Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.0.106)(PORT = 1521))) (CONNECT_DATA = (SERVICE_NAME = RACE)))";
            //OleDbConnection conn = new OleDbConnection(connString);
            //try
            //{
            //    conn.Open();
            //    MessageBox.Show(conn.State.ToString());
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
            //finally
            //{
            //    conn.Close();
            //}
            string connectionString;
            string queryString;

            connectionString = "Data Source=192.168.0.106/orcl;User ID=LVDX;PassWord=lvdx2020";

            queryString = "SELECT * FROM T_STU";

            OracleConnection myConnection = new OracleConnection(connectionString);

            OracleCommand myORACCommand = myConnection.CreateCommand();

            myORACCommand.CommandText = queryString;

            myConnection.Open();

            OracleDataReader myDataReader = myORACCommand.ExecuteReader();

            myDataReader.Read();

            Console.WriteLine("email: " + myDataReader["STUNAME"]);

            //DataTable P_dt = new DataTable();
            DataTable P_dt = myDataReader.GetSchemaTable();
            this.dataGridView1.DataSource = P_dt;
            Console.WriteLine("连接成功");

            myDataReader.Close();

            myConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }
    }
}
