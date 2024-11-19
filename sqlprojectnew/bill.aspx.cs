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

        
        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_accountdetails";
            cmd.Parameters.AddWithValue("@uid", Session["userid"]);
            cmd.Parameters.AddWithValue("@accno", TextBox1.Text);
            cmd.Parameters.AddWithValue("acctype", TextBox2.Text);
            cmd.Parameters.AddWithValue("@accbal", TextBox3.Text);
            cmd.Parameters.AddWithValue("@status", "Active");
            SqlParameter sp = new SqlParameter();
            sp.DbType = DbType.Int32;
            sp.ParameterName = "@sta";
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);
            conobj.fn_nonquery_sp(cmd);
            int i = Convert.ToInt32(sp.Value);
            if(i==1)
            {
                Response.Redirect("payment.aspx");
            }
            else
            {
                Label7.Text = "invalid account deatils";
            }



        }

    }
}