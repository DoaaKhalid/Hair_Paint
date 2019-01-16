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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Painting Hire Business System;Integrated Security=SSPI");
            con.Open();
            SqlCommand cmd = new SqlCommand("search", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(id.Text)));
            
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable tbl = new DataTable();
            tbl.Columns.Add("cus_id");
            tbl.Columns.Add("first_name");
            tbl.Columns.Add("middle_name");
            tbl.Columns.Add("last_name");
            tbl.Columns.Add("Color");
            tbl.Columns.Add("Artist_Name");
            DataRow row;
            while (rdr.Read())
            {
                row = tbl.NewRow();
                
                firstname.Text = (string)rdr["First_Name"];
                middelname.Text = (string) rdr["Meddle_Name"];
                lastname.Text = (string)rdr["Last_Name"];
                color.Text = (string)rdr["Color"];
                phone.Text = (string)rdr["Phone"];
                artist.Text =(string)rdr["Paint_ID"].ToString();
                
              //  tbl.Rows.Add(row);
            }
            rdr.Close();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Painting Hire Business System;Integrated Security=SSPI");
            con.Open();

            SqlCommand cmd = new SqlCommand("UP", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@first", Convert.ToString(firstname.Text)));
            cmd.Parameters.Add(new SqlParameter("@middel", Convert.ToString(middelname.Text)));
            cmd.Parameters.Add(new SqlParameter("@last", Convert.ToString(lastname.Text)));
            cmd.Parameters.Add(new SqlParameter("@phone", Convert.ToString(phone.Text)));
            cmd.Parameters.Add(new SqlParameter("@color", Convert.ToString(color.Text)));
            cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(id.Text)));
            cmd.Parameters.Add(new SqlParameter("@paintid", Convert.ToInt32(artist.Text)));
            
            cmd.ExecuteReader();
            con.Close();
            MessageBox.Show("Updated", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1.mp[Convert.ToInt32(id.Text)] = 1;
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Painting Hire Business System;Integrated Security=SSPI");
            con.Open();

            SqlCommand cmd = new SqlCommand("ad", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@first", Convert.ToString(firstname.Text)));
            cmd.Parameters.Add(new SqlParameter("@middel", Convert.ToString(middelname.Text)));
            cmd.Parameters.Add(new SqlParameter("@last", Convert.ToString(lastname.Text)));
            cmd.Parameters.Add(new SqlParameter("@phone", Convert.ToString(phone.Text)));
            cmd.Parameters.Add(new SqlParameter("@color", Convert.ToString(color.Text)));
            cmd.Parameters.Add(new SqlParameter("@idpaint", Convert.ToInt32(artist.Text)));
            cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(id.Text)));

            SqlParameter first = new SqlParameter("@first", firstname.Text);
            SqlParameter middle = new SqlParameter("@middel", middelname.Text);
            SqlParameter last = new SqlParameter("@last", lastname.Text);
            SqlParameter Phone = new SqlParameter("@phone", phone.Text);
            SqlParameter Color = new SqlParameter("@color", color.Text);
            SqlParameter ID = new SqlParameter("@id", id.Text);
            SqlParameter IDpaint = new SqlParameter("@idpaint", id.Text);
            
            cmd.ExecuteReader();
            con.Close();
            MessageBox.Show("Done !", "Item Added Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
