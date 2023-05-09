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

namespace bus_ticketing_sysytem
{
    public partial class businfo : UserControl
    {
        public int bus_id;
        SqlConnection conn = new SqlConnection(@"Data Source=CKS-PC🤘;Initial Catalog=try;Integrated Security=True");

        public businfo()
        {
            InitializeComponent();
            this.ActiveControl= busnotxt;
            busnotxt.Focus();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm ";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void businfo_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from bustry", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            busview.DataSource = dt;
            conn.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (busnotxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter bus no");
                }
                else if (comboBox1.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter type");
                }
                else if (noseatstxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter number of seats");
                }
                else if (busmodeltxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter model");
                }
                else if (busnametxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter bus name");
                }
                else if (driver_nametxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter driver name");
                }
                else if (conductortxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter conductor name");
                }
                else if (dateTimePicker1.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter date and time");
                }
                else if (from.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter from");
                }
                else if (to.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter destination");
                }
                else if (rprice.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter route price ");
                }
                else if (d_cont.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter driver contact ");
                }
                else if (c_cont.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter conductor contact ");
                }
                else
                {

                    //insert data
                    conn.Open();
                    SqlCommand cmd3 = new SqlCommand("insert into bustry values('" + busnotxt.Text + "','" + busnametxt.Text + "','" + comboBox1.Text + "','" + noseatstxt.Text + "','" + dateTimePicker1.Value + "','" + busmodeltxt.Text + "','" + driver_nametxt.Text + "','" + conductortxt.Text + "','" + from.Text + "','" + to.Text + "','" + rprice.Text + "','"+d_cont.Text+"','"+c_cont.Text+"')", conn);
                    cmd3.ExecuteNonQuery();
                    MessageBox.Show("data inserted");

                    //display data
                    SqlDataAdapter sda = new SqlDataAdapter("select * from bustry ", conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    busview.DataSource = dt;
                    conn.Close();

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("exception undandled"+ex);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from bustry", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                busview.DataSource = dt;
                conn.Close();
            }
            catch(System.InvalidOperationException ex) { conn.Close(); }
            catch(SqlException ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bus_id = 0;
            busmodeltxt.Clear();
            noseatstxt.Clear();
            busnametxt.Clear();
            driver_nametxt.Clear();
            conductortxt.Clear();
            from.Clear();
            to.Clear();
            busnotxt.Clear();
            rprice.Clear();
            d_cont.Clear();
            c_cont.Clear();

        }

        private void busnotxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from bustry", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            busview.DataSource = dt;
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (bus_id > 0)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from bustry where bus_id= @id", conn);
                cmd.Parameters.AddWithValue("@id", this.bus_id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("data deleted");


                SqlDataAdapter sda = new SqlDataAdapter("select * from bustry", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                busview.DataSource = dt;

                conn.Close();
            }
            else
                MessageBox.Show("select bus");
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            String s = searchbox.Text + "%";
            SqlDataAdapter sda = new SqlDataAdapter("select * from bustry where route_to like ('" + s + "')", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            busview.DataSource = dt;
            conn.Close();
        }

        private void busview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                bus_id = Convert.ToInt32(busview.SelectedRows[0].Cells[1].Value);
                busnotxt.Text = busview.SelectedRows[0].Cells[2].Value.ToString();
                busnametxt.Text = busview.SelectedRows[0].Cells[3].Value.ToString();
                comboBox1.Text = busview.SelectedRows[0].Cells[4].Value.ToString();
                noseatstxt.Text = busview.SelectedRows[0].Cells[5].Value.ToString();
                dateTimePicker1.Text = busview.SelectedRows[0].Cells[6].Value.ToString();
                busmodeltxt.Text = busview.SelectedRows[0].Cells[7].Value.ToString();
                driver_nametxt.Text = busview.SelectedRows[0].Cells[8].Value.ToString();
                conductortxt.Text = busview.SelectedRows[0].Cells[9].Value.ToString();
                from.Text = busview.SelectedRows[0].Cells[10].Value.ToString();
                to.Text = busview.SelectedRows[0].Cells[11].Value.ToString();
                rprice.Text = busview.SelectedRows[0].Cells[12].Value.ToString();
                d_cont.Text = busview.SelectedRows[0].Cells[13].Value.ToString();
                c_cont.Text = busview.SelectedRows[0].Cells[14].Value.ToString();
            }
            catch (System.InvalidCastException ex)
            {

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (bus_id > 0)
            {
                if (busnotxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter bus no");
                }
                else if (comboBox1.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter type");
                }
                else if (noseatstxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter number of seats");
                }
                else if (busmodeltxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter model");
                }
                else if (busnametxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter bus name");
                }
                else if (driver_nametxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter driver name");
                }
                else if (conductortxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter conductor name");
                }
                else if (dateTimePicker1.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter date and time");
                }
                else if (from.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter from");
                }
                else if (to.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter destination");
                }
                else if (rprice.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter route price ");
                }
                else if (d_cont.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter driver contact ");
                }
                else if (c_cont.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter conductor contact ");
                }
                else
                {


                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update bustry set bus_no=@bno,bus_name=@bname,bus_type=@type,no_of_seats=@seats,bus_time=@time,driver_name=@dname,conductor_name=@cname,route_from=@from,route_to=@to,route_price=@price,driver_contact=@dcon,conductor_contact=@ccon where bus_id=@id", conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", this.bus_id);
                    cmd.Parameters.AddWithValue("@bno", busnotxt.Text);
                    cmd.Parameters.AddWithValue("@bname", busnametxt.Text);
                    cmd.Parameters.AddWithValue("@type", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@seats", noseatstxt.Text);
                    cmd.Parameters.AddWithValue("@time", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@dname", driver_nametxt.Text);
                    cmd.Parameters.AddWithValue("@cname", conductortxt.Text);
                    cmd.Parameters.AddWithValue("@from", from.Text);
                    cmd.Parameters.AddWithValue("@to", to.Text);
                    cmd.Parameters.AddWithValue("@price", rprice.Text);
                    cmd.Parameters.AddWithValue("@dcon", d_cont.Text);
                    cmd.Parameters.AddWithValue("@ccon", c_cont.Text);
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter sda = new SqlDataAdapter("select * from bustry", conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    busview.DataSource = dt;


                    conn.Close();

                    MessageBox.Show("data updated");
                }
            }
            else
            {
                MessageBox.Show("select bus");
            }
        }

        private void busnotxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                noseatstxt.Focus();
            }
        }

        private void noseatstxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                busmodeltxt.Focus();
            }
        }

        private void busmodeltxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                busnametxt.Focus();
            }
        }

        private void busnametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                driver_nametxt.Focus();
            }
        }

        private void driver_nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                d_cont.Focus();
            }
        } 

        private void conductortxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                c_cont.Focus();
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                from.Focus();
            }
        }

        private void from_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                to.Focus();
            }
        }

        private void to_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rprice.Focus();
            }
        }

        private void rprice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }

        private void d_cont_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                conductortxt.Focus();
            }
        }

        private void c_cont_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker1.Focus();
            }
        }

        private void busview_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            busview.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();

        }

        private void conductortxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void d_cont_TextChanged(object sender, EventArgs e)
        {
            long c;
            if (!long.TryParse(d_cont.Text, out c))
            {
                d_cont.Clear();
            }
            else if (d_cont.Text.Length > 10)
            {
                MessageBox.Show("done");
            }
        }

        private void c_cont_TextChanged(object sender, EventArgs e)
        {
            long c;
            if (!long.TryParse(c_cont.Text, out c))
            {
                c_cont.Clear();
            }
            else if (c_cont.Text.Length > 10)
            {
                MessageBox.Show("done");
            }
        }

        private void rprice_TextChanged(object sender, EventArgs e)
        {
            long c;
            if (!long.TryParse(rprice.Text, out c))
            {
                rprice.Clear();
            }
            
        }

        private void noseatstxt_TextChanged(object sender, EventArgs e)
        {
            long c;
            if (!long.TryParse(noseatstxt.Text, out c))
            {
                noseatstxt.Clear();
            }
            
        }
    }
}
