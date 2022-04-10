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
        System.Timers.Timer timer1 = new System.Timers.Timer();
        int i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //GetMessage();

            DataTable P_dt = GetMessage2();
            this.dataGridView1.DataSource = P_dt;
            label1.Text = "连接成功";
        }
        private DataTable GetMessage2()
        {
            MySqlConn mc = new MySqlConn();
            MySqlConnection conn = mc.open_MySql(mc.constr);
            string SqlStr = string.Format("SELECT Host,User FROM user_test");
            MySqlDataAdapter adapter = new MySqlDataAdapter(SqlStr, conn);
            DataTable P_dt = new DataTable();
            try
            {
                adapter.Fill(P_dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }            
            mc.close_SqlServer(conn);
            return P_dt;
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

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            timer1.Interval = 8000; //设置计时器事件间隔执行时间
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(TMStart1_Elapsed);
            timer1.Enabled = true;
        }
        private void TMStart1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //执行SQL语句或其他操作
            Console.WriteLine("测试第" + i + "次job");
            //using (System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\" + 1 + "log.txt", true))
            //{
            //    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "Start.");
            //}
            i++;
            DataTable P_dt = GetMessage2();
            //dataGridView1.DataSource = P_dt;
            this.Invoke(new EventHandler(delegate
            {
                dataGridView1.DataSource = P_dt;
                string str = "第" + i + "连接成功";
                label1.Text = str;
            }));
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}
