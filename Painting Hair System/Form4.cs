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
    public partial class Form4 : Form
    {
        public static Dictionary<int, int> mp1 = new Dictionary<int, int>();
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            int n = 100000;
            for (int i = 0; i <= n; i++)
            {
                mp1[i] = 0;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form4.mp1[Convert.ToInt32(id.Text)] == 1)
            {
                MessageBox.Show("This is Already In DataBase", "Wrong");
            }

            else
            {
                Form4.mp1[Convert.ToInt32(id.Text)] = 1;
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Painting Hire Business System;Integrated Security=SSPI");
                con.Open();

                SqlCommand cmd = new SqlCommand("insertowner", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@name", Convert.ToString(name.Text)));
                cmd.Parameters.Add(new SqlParameter("@address", Convert.ToString(address.Text)));
                cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(id.Text)));
                cmd.Parameters.Add(new SqlParameter("@paint", Convert.ToInt32(paint.Text)));
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Done !", "Item Added Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Painting Hire Business System;Integrated Security=SSPI");
            con.Open();

            SqlCommand cmd = new SqlCommand("updateowner", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@name", Convert.ToString(name.Text)));
            cmd.Parameters.Add(new SqlParameter("@address", Convert.ToString(address.Text)));
            cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(id.Text)));
            cmd.Parameters.Add(new SqlParameter("@paint", Convert.ToInt32(paint.Text)));
            cmd.ExecuteReader();
            con.Close();
            MessageBox.Show("Updated", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Form4.mp1[Convert.ToInt32(id.Text)] == 1)
            {
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Painting Hire Business System;Integrated Security=SSPI");
                con.Open();
                SqlCommand cmd = new SqlCommand("deleteowner", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(id.Text)));

                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Done ! ", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form4.mp1[Convert.ToInt32(id.Text)] = 0;
            }
            else { MessageBox.Show("There is No Exists", "Wrong"); }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Painting Hire Business System;Integrated Security=SSPI");
            con.Open();
            SqlCommand cmd = new SqlCommand("displayOwner", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(id.Text)));
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Owner_ID");
            tbl.Columns.Add("Name");
            tbl.Columns.Add("Address");
            tbl.Columns.Add("PaintID");
            DataRow row;
            while (rdr.Read())
            {
                row = tbl.NewRow();
                row["Owner_ID"] = rdr["owner_ID"];
                row["Name"] = rdr["Name"];
                row["Address"] = rdr["Address"];
                row["PaintID"] = rdr["paint_id"];
                tbl.Rows.Add(row);
            }
            rdr.Close();
            con.Close();
            dataGridView1.DataSource = tbl;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Painting Hire Business System;Integrated Security=SSPI");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Owner", con);


            cmd.CommandType = CommandType.Text;
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Owner_ID");
            tbl.Columns.Add("Name");
            tbl.Columns.Add("Address");
            tbl.Columns.Add("PaintID");
            DataRow row;
            while (rdr.Read())
            {
                row = tbl.NewRow();
                row["Owner_ID"] = rdr["owner_ID"];
                row["Name"] = rdr["Name"];
                row["Address"] = rdr["Address"];
                row["PaintID"] = rdr["paint_id"];
                tbl.Rows.Add(row);
            }
            rdr.Close();
            con.Close();
            dataGridView1.DataSource = tbl;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
