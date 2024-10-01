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
    public partial class producthome : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sel = "select * from product_tb where category_id="+ Session["category_id"] + "";
                DataTable dt = conobj.fn_DataTable(sel);
                DataList1.DataSource = dt;
                DataList1.DataBind();

            }

        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            int getid = Convert.ToInt32(e.CommandArgument);
            Session["product_id"] = getid;
            Response.Redirect("itemhome.aspx");
        }
    }
}