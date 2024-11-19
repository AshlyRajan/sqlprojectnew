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
    public partial class replyfeedback : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fn_gridbind();
                
            }
        }
        public void fn_gridbind()
        {
            string sel = "select * from feedback where feed_status=0";
            DataSet ds = conobj.fn_Dataset(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        

        protected void Button1_Command(object sender, CommandEventArgs e)
        {
            //int getid = Convert.ToInt32(e.CommandArgument);
            Session["getid"] =(e.CommandArgument);
            Response.Redirect("mailreply.aspx");

        }
    }
}