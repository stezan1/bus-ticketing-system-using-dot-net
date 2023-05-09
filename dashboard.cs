using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace bus_ticketing_sysytem
{
    public partial class dashboard : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=CKS-PC🤘;Initial Catalog=try;Integrated Security=True");

        public dashboard()
        {

            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            
            //DISPLAY
            SqlDataAdapter sda = new SqlDataAdapter("select t_to, sum(price) as total from tickettry group by t_to", conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select route_to,count(bus_id) as no_of_bus from bustry group by route_to", conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select t_to, count(seat)  as no_of_seats from tickettry group by t_to", conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select bus_id,route_from,route_to,route_price,bus_no,bus_type from bustry", conn);
            SqlCommand cmd2 = new SqlCommand("select bus_id,route_from,route_to,route_price,bus_no,bus_type from bustry", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlDataAdapter da2 = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da2.SelectCommand = cmd2;
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            da.Fill(dt);
            da2.Fill(dt2);
            f.DataSource = dt;
            t.DataSource = dt2;
            f.DisplayMember = "route_from";
            t.DisplayMember = "route_to";
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string fr=f.Text;
            string to=t.Text;
            conn.Open();

            //DISPLAY
            SqlDataAdapter sda = new SqlDataAdapter("select bus_id,bus_name,bus_no,bus_type,no_of_seats,route_price from bustry where route_from like ('"+fr+"') and route_to like ('"+to+"')", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string fr = f.Text;
            string to = t.Text;
            conn.Open();

            //DISPLAY
            SqlDataAdapter sda = new SqlDataAdapter("select bus_id,bus_name,bus_no,bus_type,no_of_seats,route_price,bus_time from bustry where route_from like ('" + fr + "') and route_to like ('" + to + "')", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn.Open();

            //DISPLAY
            SqlDataAdapter sda = new SqlDataAdapter("select t_to, sum(price) as total from tickettry group by t_to", conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select route_to,count(bus_id) as no_of_bus from bustry group by route_to", conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select t_to, count(seat)  as no_of_seats from tickettry group by t_to", conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void from_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
