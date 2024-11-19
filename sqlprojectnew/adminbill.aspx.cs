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
    public partial class adminbill : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            fn_gridbind();
        }
        public void fn_gridbind()
        {
            string sel = "select * from bill_tb where bill_status='paid'";
            DataSet ds = conobj.fn_Dataset(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            fn_gridbind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            fn_gridbind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox txt = (TextBox)GridView1.Rows[i].Cells[3].FindControl("TextBox1");
            string up = "update bill_tb set bill_status='Deliverd' where bill_id=" + getid + "";
            conobj.fn_nonquery(up);
            GridView1.EditIndex = -1;
            fn_gridbind();
        }
    }
}