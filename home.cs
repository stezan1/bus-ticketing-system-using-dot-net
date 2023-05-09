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
    public partial class home : Form

       
    {

        public home()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            businfo1.Show();
            businfo1.BringToFront();
            employee1.Hide();
            ticketcountert1.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ticketcountert1.BringToFront();
            ticketcountert1.Show();
            businfo1.Hide();
            employee1.Hide();
         

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ticketcountert1.BringToFront();
            ticketcountert1.Show();
            businfo1.Hide();
            employee1.Hide();
    
        }

        private void button4_Click(object sender, EventArgs e)
        {

          
            ticketcountert1.Hide();
            businfo1.Hide();
            employee1.Show();
            employee1.BringToFront();
 

        }

        private void button6_Click(object sender, EventArgs e)
        {
     
            ticketcountert1.Hide();
            businfo1.Hide();
            employee1.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            TextBox textBox1 = new TextBox();
            MessageBox.Show(textBox1.Text);
            textBox1.Text=Console.ReadLine();
        }

        private void home_Load(object sender, EventArgs e)
        {
            if(role.type=="A")
            {
                btnticket.Visible=true;
                btnbus.Visible=true;
                btnstaff.Visible=true;
                button1.Visible=true;
                btnemployee.Visible=true;
            }
            else if(role.type=="U")
            {
                btnticket.Visible = true;
                btnbus.Visible = true;
                btnstaff.Visible = true;
                button1.Visible = true;
                btnemployee.Visible = false;

                
            }
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            
            label1.Text = "Hello "+role.uname;
        }

        private void btnticket_Click(object sender, EventArgs e)
        {
            ticketcountert1.Show();
            ticketcountert1.BringToFront();
            businfo1.Hide();
            employee1.Hide();
            about1.Hide();
            changepassword1.Hide();

        }

        private void btnbus_Click(object sender, EventArgs e)
        {
            businfo1.Show();
            businfo1.BringToFront();
            ticketcountert1.Hide();
            employee1.Hide();
            about1.Hide();
            changepassword1.Hide();


        }

        private void btnstaff_Click(object sender, EventArgs e)
        {
            about1.Show();
            about1.BringToFront();
            businfo1.Hide();
            employee1.Hide();
            ticketcountert1.Hide();
            changepassword1.Hide();

        }

        private void btnemployee_Click(object sender, EventArgs e)
        {
            employee1.Show();
            employee1.BringToFront();
            businfo1.Hide();
            ticketcountert1.Hide();
            about1.Hide();
            changepassword1.Hide();

        }

        private void btnemployee_Click_1(object sender, EventArgs e)
        {
            employee1.Show();
            employee1.BringToFront();
            businfo1.Hide();
            ticketcountert1.Hide();
            about1.Hide();
            changepassword1.Hide();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            changepassword1.BringToFront();
            changepassword1.Show();
            employee1.Hide();
            businfo1.Hide();
            ticketcountert1.Hide();
            about1.Hide();
        }

        private void ticketcountert1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           this.Hide();
            loginform l=new loginform();
            l.Show();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            dashboard1.Show();
            dashboard1.BringToFront();
        }
    }
}
