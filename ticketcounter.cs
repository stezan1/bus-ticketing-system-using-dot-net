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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bus_ticketing_sysytem
{
    public partial class ticketcountert : UserControl
    {
        int id;
        int route_id=0;
        SqlConnection conn = new SqlConnection(@"Data Source=CKS-PC🤘;Initial Catalog=try;Integrated Security=True");

        public ticketcountert()
        {
            InitializeComponent();
            this.ActiveControl = nametxt;
            nametxt.Focus();


          for (int i = 1; i <= 45; i++)
            {
                seattxt.Items.Add(i.ToString());
            }



            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm";

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            label3.Text = role.uname;

            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from tickettry", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            pricetxt.Text = "0";


          



            //display combobox items from database
            conn.Open();
            SqlCommand cmd = new SqlCommand("select bus_id,route_from,route_to,route_price,bus_no,bus_type,no_of_seats from bustry", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            fromtxt.DataSource = dt;
            totxt.DataSource = dt;
            pricecombo.DataSource = dt;
            busnocombo.DataSource = dt;
            bustype.DataSource = dt;
            comboBox2.DataSource = dt;
            busnocombo.DisplayMember = "bus_no";
            bustype.DisplayMember = "bus_type";
            fromtxt.DisplayMember = "route_from";
            fromtxt.ValueMember = "bus_id";
            totxt.DisplayMember = "route_to";
            pricecombo.DisplayMember = "route_price";
            comboBox2.DisplayMember = "no_of_seats";

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (nametxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter name");
                } 
                else if (agetxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter age");
                }else if (addresstxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter address");
                }else if (phtxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter phone number");
                }else if (dateTimePicker1.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter date");
                }else if (fromtxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter from");
                }else if (totxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter destination");
                }else if (no_of_tickettxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter number of tickets");
                }else if (ticketnotxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter ticket number");
                }else if (seattxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter seat number");
                }
                else
                {

                    conn.Open();
                    //input data
                    SqlCommand cmd = new SqlCommand("insert into tickettry values('" + ticketnotxt.Text + "','" + nametxt.Text + "','" + addresstxt.Text + "','" + phtxt.Text + "','" + agetxt.Text + "','" + no_of_tickettxt.Text + "','"+fromtxt.Text+"','"+totxt.Text+"','"+busnocombo.Text+"','"+bustype.Text+"','"+pricetxt.Text+"','"+seattxt.Text+"','"+dateTimePicker1.Value+"')", conn);
                    cmd.ExecuteNonQuery();
                   


                    //dislay
                    SqlDataAdapter sda = new SqlDataAdapter("select * from tickettry", conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView2.DataSource = dt;
                    conn.Close();

                    //print out
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.ShowDialog();


                    //remove selected item from combobox
                    seattxt.Items.Remove(seattxt.SelectedItem);

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("exception undandled" + ex);
            }
            
        
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            id = 0;
            nametxt.Clear();
            agetxt.Clear();
            addresstxt.Clear();
            phtxt.Clear();
            ticketnotxt.Clear();
            no_of_tickettxt.Clear();
            pricetxt.Clear();
            
            
        }

        private void fromtxt_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from tickettry", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            String s = searchbox.Text + "%";
            SqlDataAdapter sda = new SqlDataAdapter("select * from tickettry where p_name like ('"+s+"')", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }

        private void phtxt_TextChanged(object sender, EventArgs e)
        {
            long c;
            if (!long.TryParse(phtxt.Text, out c))
            {
                phtxt.Clear();
            }
            else if (phtxt.Text.Length > 10)
            {
                MessageBox.Show("exceeded");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void addresstxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void agetxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void nametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                if (nametxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter name");
                }
                else if (agetxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter age");
                }
                else if (addresstxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter address");
                }
                else if (phtxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter phone number");
                }
                else if (dateTimePicker1.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter date and time");
                }
                else if (fromtxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter from");
                }
                else if (totxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter destination");
                }
                else if (no_of_tickettxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter number of tickets");
                }
                else if (ticketnotxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter ticket number");
                }
                else if (seattxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Enter seat number");
                }

                else
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update tickettry set ticket_no=@tno , p_name=@name ,p_addr=@addr,p_contact=@contact,age_sex=@age_sex,no_of_tickets=@tickets,t_from=@from,t_to=@to,bus_no=@busno,bus_type=@bustype,price=@price,seat=@seatno,date=@date where ticket_id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", this.id);
                    cmd.Parameters.AddWithValue("@tno", ticketnotxt.Text);
                    cmd.Parameters.AddWithValue("@name", nametxt.Text);
                    cmd.Parameters.AddWithValue("@addr", addresstxt.Text);
                    cmd.Parameters.AddWithValue("@contact", phtxt.Text);
                    cmd.Parameters.AddWithValue("@age_sex", agetxt.Text);
                    cmd.Parameters.AddWithValue("@tickets", no_of_tickettxt.Text);
                    cmd.Parameters.AddWithValue("@from", fromtxt.Text);
                    cmd.Parameters.AddWithValue("@to", totxt.Text);
                    cmd.Parameters.AddWithValue("@busno", busnocombo.Text);
                    cmd.Parameters.AddWithValue("@bustype", bustype.Text);
                    cmd.Parameters.AddWithValue("@price", pricetxt.Text);
                    cmd.Parameters.AddWithValue("@seatno", seattxt.Text);
                    cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                   
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("data updated");
                    SqlDataAdapter sda = new SqlDataAdapter("select * from tickettry", conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView2.DataSource = dt;
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("select ticket");
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                    id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[1].Value);
                    ticketnotxt.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                    nametxt.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
                    addresstxt.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
                    phtxt.Text = dataGridView2.SelectedRows[0].Cells[5].Value.ToString();
                    agetxt.Text = dataGridView2.SelectedRows[0].Cells[6].Value.ToString();
                    no_of_tickettxt.Text = dataGridView2.SelectedRows[0].Cells[7].Value.ToString();
                    fromtxt.Text = dataGridView2.SelectedRows[0].Cells[8].Value.ToString();
                    totxt.Text = dataGridView2.SelectedRows[0].Cells[9].Value.ToString();
                    busnocombo.Text = dataGridView2.SelectedRows[0].Cells[10].Value.ToString();
                    bustype.Text = dataGridView2.SelectedRows[0].Cells[11].Value.ToString();
                    pricecombo.Text = dataGridView2.SelectedRows[0].Cells[12].Value.ToString();
                    seattxt.Text = dataGridView2.SelectedRows[0].Cells[13].Value.ToString();
                    dateTimePicker1.Text = dataGridView2.SelectedRows[0].Cells[14].Value.ToString();
                
            }
            
             catch (System.InvalidCastException ex)
            {

            }
          
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from tickettry where ticket_id=@id", conn);
                cmd.Parameters.AddWithValue("@id", this.id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("data deleted");
                SqlDataAdapter sda = new SqlDataAdapter("select * from tickettry", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
                conn.Close();
            }
            else
            {
                MessageBox.Show("select ticket");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Welcome to dhangadi bus service", new Font("Arial", 35, FontStyle.Regular), Brushes.Black, new Point(0, 0));
            e.Graphics.DrawString("name : " + nametxt.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 50));
            e.Graphics.DrawString("age : " + agetxt.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(550, 50));
            e.Graphics.DrawString("from : " + fromtxt.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 100));
            e.Graphics.DrawString("to : " + totxt.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(550, 100));
            e.Graphics.DrawString("seat number : " + seattxt.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 150));
            e.Graphics.DrawString("no. of tickets : " + no_of_tickettxt.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(550, 150));
            e.Graphics.DrawString("departure date : " + dateTimePicker1.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 200));
            e.Graphics.DrawString("bus number : "+busnocombo.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(550, 250));
            e.Graphics.DrawString("bus type : "+bustype.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 300));
            e.Graphics.DrawString("total price : "+pricetxt.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(550, 300));
            e.Graphics.DrawString("username : " + label3.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 350));
            e.Graphics.DrawString("system time : " + System.DateTime.Today, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 400));
            e.Graphics.DrawString("THANKYOU FOR CHOOSING OUR SERVICE ", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 450));
        }

        private void pricetxt_TextChanged(object sender, EventArgs e)
        {
            long c;
            if (!long.TryParse(pricetxt.Text, out c))
            {
                pricetxt.Clear();
            }
        }

        private void no_of_tickettxt_TextChanged(object sender, EventArgs e)
        {
              long c;
              if (no_of_tickettxt.Text.Equals(string.Empty))
              {
                  pricetxt.Text = "0";
              }

              else if (!long.TryParse(no_of_tickettxt.Text, out c))
              {
                  no_of_tickettxt.Clear();
              }
              else
              {
                  string a = pricecombo.Text;
                  string b = no_of_tickettxt.Text;
                  float total;
                  total = Convert.ToInt32(a) * Convert.ToInt32(b);
                  pricetxt.Text = total.ToString();
              }
            

        }

        private void nametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                agetxt.Focus();
            }
        }

        private void agetxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addresstxt.Focus();
            }
        }

        private void addresstxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                phtxt.Focus();
            }
        }

        private void phtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fromtxt.Focus();
            }
        }

        private void fromtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totxt.Focus();
            }
        }

        private void totxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                no_of_tickettxt.Focus();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pricecombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (no_of_tickettxt.Text.Equals(string.Empty))
            {
                pricetxt.Text = "0";
            }
            else
            {
                string a = pricecombo.Text;
                string b = no_of_tickettxt.Text;
                float total;
                total = Convert.ToInt32(a) * Convert.ToInt32(b);
                pricetxt.Text = total.ToString();
            }
        }

        private void no_of_tickettxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ticketnotxt.Focus();
            }
        }

        private void ticketnotxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                seattxt.Focus();
            }
        }

        private void seattxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }

        private void no_of_tickettxt_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView2.Rows[e.RowIndex].Cells[0].Value= (e.RowIndex+1).ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void time_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void seattxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            /*int s = Convert.ToInt32(comboBox2.SelectedItem.ToString());
             if (comboBox2.Text.Equals(string.Empty))
             {
                 seattxt.Items.Clear();
             }
             else
             {
                 for (int i = 1; i <=s; i++)
                 {
                     seattxt.Items.Add(i.ToString());
                 }
             }*/
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
