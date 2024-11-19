using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sqlprojectnew
{
    public partial class mailreply : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sel = "select Email from user_reg where user_id=" + Session["getid"] + "";
            string s = conobj.fn_scalar(sel);
            TextBox1.Text = s;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string t = TextBox1.Text;
            string s = TextBox2.Text;
            string r = TextBox3.Text;
            SendEmail2("ashly", "ashlykalappurackal@gmail.com", "lyfw hdtv kfvj mjom", "anu", t, s, r);
            string up = "update feedback set replay='" + TextBox3.Text + "',feed_status=1 where user_id=" + Session["getid"] + "";
            int i = conobj.fn_nonquery(up);
            if (i == 1)
            {
                Label1.Visible = true;
                Label1.Text = "successfully send";
            }
        }
        public static void SendEmail2(string yourName, string yourGmailUserName, string yourGmailPassword, string toName, string toEmail, string subject, string body)

        {
            string to = toEmail; //To address    
            string from = yourGmailUserName; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = body;
            message.Subject = subject;
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential(yourGmailUserName, yourGmailPassword);
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}