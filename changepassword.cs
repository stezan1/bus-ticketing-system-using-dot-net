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
    public partial class changepassword : UserControl
    {
        
        SqlConnection conn = new SqlConnection(@"Data Source=CKS-PC🤘;Initial Catalog=try;Integrated Security=True");

        public changepassword()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(string.Empty))
            {
                MessageBox.Show("enter old password");
            }
            else if (textBox2.Text.Equals(string.Empty) )
                {
                    MessageBox.Show("enter new password");
                }
            else if (textBox3.Text.Equals(string.Empty))
            {
                        MessageBox.Show("enter new password");
            }
            else if (textBox1.Text.Length < 4)
            {
                MessageBox.Show("old password cannot be less than 4 digits");
            }
            else if (textBox2.Text.Length < 4)
            {
                MessageBox.Show("new password cannot be less than 4 digits");
            }
            else if (textBox3.Text.Length < 4)
            {
                MessageBox.Show("confirm password cannot be less than 4 digits");
            } 
            else
            {

                if (textBox1.Text == role.password)
                {


                    if (textBox2.Text == textBox3.Text)
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("update employeetry set password ='" + textBox3.Text + "' where username ='" + role.uname + "'  ", conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("password changed successfully\nlogin again");
                        this.ParentForm.Hide();
                        loginform l = new loginform();
                        l.Show();
                        conn.Close();
                    }

                    else
                    {
                        MessageBox.Show("new password not matched");
                    }
                }
                else
                {
                    MessageBox.Show("wrong old password");
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            login l=new login();
            this.Parent.Controls.Add(l);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.Focus();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar=true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked)
            {
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                textBox3.UseSystemPasswordChar=true;
            }
            
        }

        private void changepassword_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            textBox3.UseSystemPasswordChar = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
