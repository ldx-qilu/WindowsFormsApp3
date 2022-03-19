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
            adapter.Fill(P_dt);
            this.dataGridView1.DataSource = P_dt;
            return P_dt;
        }
    }
}
