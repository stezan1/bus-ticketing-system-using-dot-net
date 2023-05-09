using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace bus_ticketing_sysytem
{
    public partial class forgetpassword : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=CKS-PC🤘;Initial Catalog=try;Integrated Security=True");

        string randomCode = "";
        public static string to;
        public forgetpassword()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            



            if (textBox1.Text.Equals(string.Empty))
            {
                MessageBox.Show("enter username");
            }
            else if (textBox2.Text.Equals(string.Empty))
            {
                MessageBox.Show("enter email");
            }
            else if (textBox3.Text.Equals(string.Empty))
            {
                MessageBox.Show("enter phone no.");
            }
            else if (textBox4.Text.Equals(string.Empty))
            {
                MessageBox.Show("enter citizenship no.");
            }
            else
            {
                conn.Open();
                SqlCommand cmd1 = new SqlCommand("select * from employeetry where username=('" + textBox1.Text + "') and email =('" + textBox2.Text + "') and employee_contact=('"+textBox3.Text+"') and citizenhsip_no=('"+textBox4.Text+"')", conn);

                SqlDataReader dr = cmd1.ExecuteReader();
                if(dr.Read())
                {
                    string pw ="password : "+ dr.GetValue(10).ToString();
                    MessageBox.Show(pw);
                }
                else
                {
                    MessageBox.Show("wrong details");
                }
                conn.Close();
            }





            /*     
                  
                  string from, pass, messagebody;
        #region Generating random code
        Random ran = new Random();
        string randText = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        int Length_randText = randText.Length;
        for (int i = 0; i < 5; i++)
        {
            randomCode += randText[ran.Next(Length_randText)];
        }
        #endregion

                        MessageBox.Show("enter 6 digit code sent to your email");
                        string from, pass, msgbody;
                        Random rand = new Random();
                        randomcode =(rand.Next(999999)).ToString();
                        MailMessage msg = new MailMessage();
                        to = (textBox2.Text).ToString();
                        from = "reahamc29@gmail.com";
                        pass = "ARju90@#";
                        msgbody = "your reset code is " +randomcode;
                        msg.To.Add(to);
                        msg.From=new MailAddress(from);
                        msg.Body = msgbody;
                        msg.Subject = "password reset code";
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        smtp.EnableSsl = true;
                        smtp.Port = 587;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Credentials = new NetworkCredential(from, pass);
                       // try
                        {
                            smtp.Send(msg);
                            MessageBox.Show("code sent successfully");
                        }
                       // catch(Exception ex)
                        {
                            //MessageBox.Show(ex.Message);
                        }

             */




        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            login f2 = new login();
            this.Parent.Controls.Add(f2);
           


        }

        private void button3_Click(object sender, EventArgs e)
        {
          
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
                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.Focus();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            long c;
            if (!long.TryParse(textBox3.Text, out c))
            {
                textBox3.Clear();
            }
            else if (textBox3.Text.Length > 10)
            {
                MessageBox.Show("exceeded");

            }
        }
    }
}
