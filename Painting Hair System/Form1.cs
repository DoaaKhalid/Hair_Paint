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
namespace Painting_Hair_System
{
    public partial class Form1 : Form
    {
          public static Dictionary<int, int> mp = new Dictionary<int, int>();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int n = 100000;
        for(int i = 0;i<=n;i++)mp[i]=0;

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Painting Hire Business System;Integrated Security=SSPI");
            con.Open();
            SqlCommand cmd = new SqlCommand("select cus_id from Customer",con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                mp[(int)rdr["cus_id"]]=1;
            }
            if (textBox1.Text == "Admin" && textBox2.Text == "12345")
            {
                this.Hide();
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }
            else
            {
                MessageBox.Show("This is Invalid" , "wrong" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
            rdr.Close();
            con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
