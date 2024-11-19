using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace sqlprojectnew
{
    public partial class Feedback : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ins = "insert into feedback values(" + Session["userid"] + ",'" + TextBox1.Text + "','0','0')";
            int i = conobj.fn_nonquery(ins);
            if(i==1)
            {
                Label1.Visible = true;
                Label1.Text = "successfully submitted";
            }
        }
    }
}