using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bus_ticketing_sysytem
{
    public partial class about : UserControl
    {
        public about()
        {
            InitializeComponent();
        }

        private void staff_Load(object sender, EventArgs e)
        {

        }

        private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (faqbox.Text.Equals(string.Empty))
            {
                MessageBox.Show("text field cannot be empty");
            }
            else
            {
                string from, pass, msgbody, to;
                MailMessage msg = new MailMessage();
                to = "shahuchandan537@gmail.com";
                from = "reahamc29@gmail.com";
                pass = "ARju90@#";
                msgbody = faqbox.Text;
                msg.To.Add(to);
                msg.From = new MailAddress(from);
                msg.Body = msgbody;
                msg.Subject = "faq from bus ticketing system";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);
                try
                {
                    smtp.Send(msg);
                    MessageBox.Show("faq sent successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
