using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetMessage();
        }
        private DataTable GetMessage()
        {
            string P_Str_ConnectionStr = string.Format("server={0};user id = {1};pwd = 'lvdx2020';port = {2};database=mysql;pooling = false;", "localhost", "root", 3306);
            string P_Str_SqlStr = string.Format("SELECT Host,User FROM user_test");
            MySqlDataAdapter adapter = new MySqlDataAdapter(P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();
            try
            {
                adapter.Fill(P_dt);
                this.dataGridView1.DataSource = P_dt;
                label1.Text = "连接成功";
            }
            catch (Exception ex)
            {
                label1.Text = ex.InnerException.Message;
                //throw;
            }    
            
            foreach (System.Data.DataRow row in P_dt.Rows)

            {

                foreach (System.Data.DataColumn col in P_dt.Columns)

                {

                    Console.WriteLine("{0} = {1}", col.ColumnName, row[col]);

                }

            }
            return P_dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constr = string.Format("server={0};uid = {1};pwd = 'sa2012';;database=Datatest", "localhost", "sa");
            SqlConnection con = new SqlConnection(constr);
            //con.Open();
            int count = this.dataGridView1.Rows.Count-1;
            for (int i = 0;i < count;i++)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "select * from tb_User where UserName = '" + this.dataGridView1.Rows[i].Cells[0].Value.ToString() + " ';";                              
                SqlDataReader sdr = cmd.ExecuteReader();
                if(sdr.Read())
                {
                    sdr.Close();
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    //con.Close();
                }
                else
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    //con.Close();

                    con.Open();
                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandText = "insert into tb_User (UserName, UserPwd) values ('" + this.dataGridView1.Rows[i].Cells[0].Value.ToString() + "','" + "123456" + "');";
                    int ic = cmd1.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    //con.Close();
                }
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

        }
    }
}
