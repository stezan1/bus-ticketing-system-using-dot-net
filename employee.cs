using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bus_ticketing_sysytem
{
    public partial class employee : UserControl
    {
        public int emp_id;
        SqlConnection conn = new SqlConnection(@"Data Source=CKS-PC🤘;Initial Catalog=try;Integrated Security=True");

        

        public employee()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            long c;
            if (!long.TryParse(phno.Text, out c))
            {
                phno.Clear();
            }
            else if (phno.Text.Length > 10)
            {
                MessageBox.Show("exceeded");

            }
         
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            emp_id = 0;
            empname.Clear();
            eaddr.Clear();
            empaddr.Clear();
            phno.Clear();
            agesex.Clear();
            fname.Clear();
            cno.Clear();
            uname.Clear();
            pwtxt.Clear();
            
            
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (empname.Text.Equals(string.Empty))
                {
                    MessageBox.Show("enter name");
                }else if (empaddr.Text.Equals(string.Empty))
                {
                    MessageBox.Show("enter address");
                }else if (fname.Text.Equals(string.Empty))
                {
                    MessageBox.Show("enter father's name");
                }else if (cno.Text.Equals(string.Empty))
                {
                    MessageBox.Show("enter citizenship number");
                }else if (rstatus.Text.Equals(string.Empty))
                {
                    MessageBox.Show("enter relationship status");
                }else if (phno.Text.Equals(string.Empty))
                {
                    MessageBox.Show("enter phone number");
                }else if (eaddr.Text.Equals(string.Empty))
                {
                    MessageBox.Show("enter email");
                }else if (uname.Text.Equals(string.Empty))
                {
                    MessageBox.Show("enter username");
                }else if (pwtxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("enter password");
                }else if (type.Text.Equals(string.Empty))
                {
                    MessageBox.Show("select type");
                }
                else if (pwtxt.Text.Length < 4)
                {
                    MessageBox.Show("password cannot be less than 4 digits");
                }
                else
                {
                    //INSERT 
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into employeetry values('" + empname.Text + "','" + eaddr.Text + "','" + phno.Text + "','" + eaddr.Text + "','" + cno.Text + "','" + fname.Text + "','" + agesex.Text + "','" + rstatus.Text + "','"+uname.Text+"','"+pwtxt.Text+"','"+type.Text+"','"+dateTimePicker2.Value+"')", conn);
                    cmd.ExecuteNonQuery();


                    //DISPLAY
                    SqlDataAdapter sda = new SqlDataAdapter("select employee_id,employee_name,employee_addr,employee_contact,email,citizenhsip_no,father_name,age_sex,realationship_status,username,type,dob from employeetry", conn);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    MessageBox.Show("data inserted");

                    //print 
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.ShowDialog();


                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("exception unsdandled"+ex);
            }
            conn.Close();

          
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string suffix=password_generator.GeneratePassword(3);
            uname.Text = empname.Text + suffix;
            string pw1 = password_generator.GeneratePassword(8);
            pwtxt.Text = pw1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            
            SqlDataAdapter sda = new SqlDataAdapter("select employee_id,employee_name,employee_addr,employee_contact,email,citizenhsip_no,father_name,age_sex,realationship_status,username,type,dob from employeetry", conn);
            
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            String search = searchbox.Text+"%";
            SqlDataAdapter sda = new SqlDataAdapter("select employee_id,employee_name,employee_addr,employee_contact,email,citizenhsip_no,father_name,age_sex,realationship_status,username,type,dob from employeetry where employee_name like ('" + search + "')", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (emp_id > 0)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from employeetry where employee_id=@id", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", this.emp_id);
                cmd.ExecuteNonQuery();
                conn.Close();

                SqlDataAdapter sda = new SqlDataAdapter("select employee_id,employee_name,employee_addr,employee_contact,email,citizenhsip_no,father_name,age_sex,realationship_status,username,type,dob from employeetry", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                MessageBox.Show("data deleted");
            }
            else
                MessageBox.Show("select employee to delete");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                emp_id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value);
                empname.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                empaddr.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                phno.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                eaddr.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                cno.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                fname.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                agesex.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                rstatus.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                uname.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                type.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                dateTimePicker2.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                
            }
            catch(System.InvalidCastException ex)
            {

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (emp_id > 0)
            {
                if (empname.Text.Equals(string.Empty))
                {
                    MessageBox.Show("enter name");
                }
                else if (empaddr.Text.Equals(string.Empty))
                {
                    MessageBox.Show("enter address");
                }
                else if (fname.Text.Equals(string.Empty))
                {
                    MessageBox.Show("enter father's name");
                }
                else if (cno.Text.Equals(string.Empty))
                {
                    MessageBox.Show("enter citizenship number");
                }
                else if (rstatus.Text.Equals(string.Empty))
                {
                    MessageBox.Show("enter relationship status");
                }
                else if (phno.Text.Equals(string.Empty))
                {
                    MessageBox.Show("enter phone number");
                }
                else if (eaddr.Text.Equals(string.Empty))
                {
                    MessageBox.Show("enter email");
                }
                else if (uname.Text.Equals(string.Empty))
                {
                    MessageBox.Show("enter username");
                }
                else if (pwtxt.Text.Equals(string.Empty))
                {
                    MessageBox.Show("enter password");
                }
                else if (type.Text.Equals(string.Empty))
                {
                    MessageBox.Show("select type");
                }
                else
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE employeetry set employee_name=@name,employee_addr=@addr,employee_contact=@contact,email=@email, citizenhsip_no=@cno ,father_name=@fname ,age_sex=@age_sex ,realationship_status=@rstatus,username=@uname,password=@pwd,type=@type,dob=@dob where employee_id=@id", conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", this.emp_id);
                    cmd.Parameters.AddWithValue("@name", empname.Text);
                    cmd.Parameters.AddWithValue("@addr", empaddr.Text);
                    cmd.Parameters.AddWithValue("@contact", phno.Text);
                    cmd.Parameters.AddWithValue("@email", eaddr.Text);
                    cmd.Parameters.AddWithValue("@cno", cno.Text);
                    cmd.Parameters.AddWithValue("@fname", fname.Text);
                    cmd.Parameters.AddWithValue("@age_sex", agesex.Text);
                    cmd.Parameters.AddWithValue("@rstatus", rstatus.Text);
                    cmd.Parameters.AddWithValue("@uname", uname.Text);
                    cmd.Parameters.AddWithValue("@pwd", pwtxt.Text);
                    cmd.Parameters.AddWithValue("@type", type.Text);
                    cmd.Parameters.AddWithValue("@dob", dateTimePicker2.Value);
                    cmd.ExecuteNonQuery();


                    SqlDataAdapter sda = new SqlDataAdapter("select employee_id,employee_name,employee_addr,employee_contact,email,citizenhsip_no,father_name,age_sex,realationship_status,username,type,dob from employeetry", conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;

                    conn.Close();

                    MessageBox.Show("data updated");
                }
            }
            else
                MessageBox.Show("select employee to update");
        }

        private void employee_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select employee_id,employee_name,employee_addr,employee_contact,email,citizenhsip_no,father_name,age_sex,realationship_status,username,type,dob from employeetry", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString("username :" + uname.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 50));
            e.Graphics.DrawString("type:" + type.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 100));
            e.Graphics.DrawString("password :" + pwtxt.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 150));
            e.Graphics.DrawString("please change your password", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 200));
        }

        private void empname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                empaddr.Focus();
            }
        }

        private void empaddr_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                agesex.Focus();
            }
        }

        private void agesex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                phno.Focus();
            }
        }

        private void phno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                eaddr.Focus();
            }
        }

        private void eaddr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fname.Focus();
            }
        }

        private void fname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cno.Focus();
            }
        }

        private void cno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rstatus.Focus();
            }
        }

        private void rstatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                uname.Focus();
            }
        }

        private void uname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                type.Focus();
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();

        }
    }
}
