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
            string P_Str_SqlStr = string.Format("SELECT Host,User FROM user");
            MySqlDataAdapter adapter = new MySqlDataAdapter(P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();
            try
            {
                adapter.Fill(P_dt);
            }
            catch (Exception ex)
            {
                label1.Text = ex.InnerException.Message;
                //throw;
            }
            
            this.dataGridView1.DataSource = P_dt;
            label1.Text = "连接成功";
            return P_dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            this.Close();
        }
    }
}
