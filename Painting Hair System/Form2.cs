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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Painting Hire Business System;Integrated Security=SSPI");
            con.Open();
            SqlCommand cmd = new SqlCommand("display" , con);

            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add(new SqlParameter("@id",Convert.ToInt32(textBox1.Text)));


         
            //SqlParameter id = new SqlParameter("@id", textBox1.Text);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable tbl = new DataTable();
            tbl.Columns.Add("cus_id");
            tbl.Columns.Add("first_name");

            tbl.Columns.Add("Color");
            tbl.Columns.Add("Artist_Name");
            DataRow row;
            while ( rdr.Read())
            {
                row = tbl.NewRow();
                row["cus_id"] = rdr["cus_id"];
                row["first_name"] = rdr["First_Name"];
                row["Color"] = rdr["Hire_color"];
                row["Artist_Name"] = rdr["Artist_Name"];
                tbl.Rows.Add(row);
            }
            rdr.Close();
            con.Close();
            dataGridView1.DataSource = tbl;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.mp[Convert.ToInt32(textBox1.Text)] == 1)
            {
                MessageBox.Show("This is Already In DataBase", "Wrong");
            }

            else
            {
                this.Hide();
                Form3 f3 = new Form3();
                f3.ShowDialog();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Painting Hire Business System;Integrated Security=SSPI");
            con.Open();
            SqlCommand cmd = new SqlCommand("displayall", con);
       

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable tbl = new DataTable();
            tbl.Columns.Add("first_name");
            tbl.Columns.Add("cus_id");    
            tbl.Columns.Add("Color");
            tbl.Columns.Add("Artist_Name");
            DataRow row;
            while (rdr.Read())
            {
                row = tbl.NewRow();
                row["cus_id"] = rdr["cus_id"];
                row["first_name"] = rdr["First_Name"];
                row["Color"] = rdr["Hire_color"];
                row["Artist_Name"] = rdr["Artist_Name"];
                tbl.Rows.Add(row);
            }
            rdr.Close();
            con.Close();
            dataGridView1.DataSource = tbl;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Form1.mp[Convert.ToInt32(textBox1.Text)] == 1)
            {
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Painting Hire Business System;Integrated Security=SSPI");
                con.Open();
                SqlCommand cmd = new SqlCommand("del", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(textBox1.Text)));
                SqlParameter id = new SqlParameter("@id", textBox1.Text);
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Done ! ", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form1.mp[Convert.ToInt32(textBox1.Text)] = 0;
            }
            else { MessageBox.Show("There is No Exists", "Wrong"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Form1.mp[Convert.ToInt32(textBox1.Text)] == 1)
            {
                this.Hide();
                Form3 f3 = new Form3();
                f3.ShowDialog();
            }
            else { MessageBox.Show("This is Not Exists" , "Wrong"); }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
