using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sqlprojectnew
{
    public partial class login : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select count(Reg_id)from login where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
            string cid = conobj.fn_scalar(str);
            int cid1 = Convert.ToInt32(cid);
            if (cid1 == 1)
            {
                string str1 = "select Reg_id from login where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
                string regid = conobj.fn_scalar(str1);
                Session["userid"] = regid;
                string str2 = "select Log_type from login where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
                string logtype = conobj.fn_scalar(str2);
                if (logtype == "admin")
                {
                    Response.Redirect("adminhome.aspx");
                }
                else if (logtype == "user")
                {
                    Response.Redirect("userhome.aspx");
                }
            }
            else
            {
                Label1.Text = "invalid username and password";
            }



        }
    }
}