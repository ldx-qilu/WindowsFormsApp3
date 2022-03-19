using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        //string constr = "Sever='localhost'; uid='sa'; pwd='sa2012'; database=''Datatest";
        string constr = string.Format("server={0};uid = {1};pwd = 'sa2012';;database=Datatest", "localhost", "sa");
        //"Sever='localhost'; uid='sa'; pwd='sa2012'; database=''Datatest";
        public Form2()
        {
            InitializeComponent();
        }

        //private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    Hide();
        //    Form1 f1 = new Form1();
        //    f1.ShowDialog();
        //    this.Close();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from tb_User;";
            SqlDataReader sdr = cmd.ExecuteReader();
            while(sdr.Read())
            {
                ListViewItem it = new ListViewItem();
                it.Text = sdr["UserName"].ToString().Trim();
                it.SubItems.Add(sdr["UserPwd"].ToString().Trim());
                it.SubItems.Add(sdr["Note"].ToString().Trim());
                listView1.Items.Add(it);
            }
            sdr.Close();
            con.Close();
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
