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
    public partial class login : UserControl
    {
       

        SqlConnection conn = new SqlConnection(@"Data Source=CKS-PC🤘;Initial Catalog=try;Integrated Security=True");

        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text.Equals(string.Empty))
            {
                MessageBox.Show("enter username");
            }
            else if (passwd.Text.Equals(string.Empty))
            {
                MessageBox.Show("enter password");
            }else if (passwd.Text.Length<4)
            {
                MessageBox.Show("password cannot be less than 4 digits");
            }
            else
            {
                conn.Open();
                SqlCommand cmd1 = new SqlCommand("select * from employeetry where username=('"+ username.Text + "') and password =('"+ passwd.Text + "')", conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                 
                
                int i = cmd1.ExecuteNonQuery();

                SqlDataReader rd = cmd1.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    if (rd[11].ToString() == "admin")
                    {
                        role.type = "A";
                    }
                    else if (rd[11].ToString() == "user")
                    {
                        role.type = "U";

                    }
                }

                    if (dt.Rows.Count > 0)
                {
                    role.uname = username.Text;
                    role.password = passwd.Text;
                    this.ParentForm.Hide();
                    home home = new home();
                    home.Show();
                }
                else
                {
                    MessageBox.Show("invalid Username or Password");
                }
                    conn.Close();
            }

       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            forgetpassword fp = new forgetpassword();
            this.Parent.Controls.Add(fp);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwd_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
            if (checkBox1.Checked)
            {
                passwd.UseSystemPasswordChar = false;
            }
            else 
            {
                passwd.UseSystemPasswordChar= true;
            }
        }

        private void username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                passwd.Focus();
            }
        }

        private void passwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            passwd.UseSystemPasswordChar=true;
        }
    }
}
