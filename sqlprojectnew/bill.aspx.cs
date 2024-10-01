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
    public partial class bill : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        
        {
            if (!IsPostBack)
            {
                string sel = "select sum(grand_total)from bill_tb where user_id=" + Session["userid"] + "";
                Label3.Text = conobj.fn_scalar(sel);
                string sel1 = "select bill_id,date from bill_tb where user_id=" + Session["userid"] + "";
                SqlDataReader dr = conobj.fn_Reader(sel1);
                while (dr.Read())
                {
                    Label1.Text = dr["Bill_id"].ToString();
                    Label2.Text = dr["date"].ToString();
                }
                gridbind_fn();
            }

        }
        public void gridbind_fn()
        {
            string sel = "select dbo.product_tb.product_name,dbo.order_tb.quantity,dbo.order_tb.total_price from dbo.order_tb inner join dbo.product_tb on dbo.order_tb.product_id=dbo.product_tb.product_id and user_id=" + Session["userid"] + "";
            DataSet ds = conobj.fn_Dataset(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}