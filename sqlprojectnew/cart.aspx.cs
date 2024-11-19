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
    public partial class cart : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridbind_fn();
            }
            string sum = "select sum(total_price) from cart where user_id=" + Session["userid"] + "";
            string s = conobj.fn_scalar(sum);
            Label6.Text=s; 
        }
        public void gridbind_fn()
        {
            string sel = "select product_tb.product_id,product_tb.product_img,product_tb.product_name,product_tb.product_price,cart.product_id,cart.qauntity,cart.total_price from product_tb INNER JOIN cart on product_tb.product_id=cart.product_id";
            DataSet ds = conobj.fn_Dataset(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gridbind_fn();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            string del = "delete from cart where product_id=" + getid + "";
            conobj.fn_nonquery(del);
            gridbind_fn();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gridbind_fn();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
             int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            string sel = "select product_price from product_tb where product_id=" + getid + "";
            string pp = conobj.fn_scalar(sel);
            Session["price"] = pp;
            TextBox txtquan = (TextBox)GridView1.Rows[i].Cells[3].FindControl("TextBox1");
            decimal j = Convert.ToDecimal(Session["price"]) * Convert.ToDecimal(txtquan.Text);
             string strup = "update cart set qauntity="+txtquan.Text+", total_price='" + j + "',where category_id=" + getid + "";
            conobj.fn_nonquery(strup);
            GridView1.EditIndex = -1;
            gridbind_fn();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select * from cart where user_id=" + Session["userid"] + "";
            List<int> lis = new List<int>();
            SqlDataReader dr = conobj.fn_Reader(sel);
            while (dr.Read())
            {
                lis.Add(Convert.ToInt32(dr["cart_id"]));
            }
            foreach(int i in lis)
            {
                string sel1 = "select * from cart where (cart_id=" + i + " AND user_id=" + Session["userid"] + ")";
                SqlDataReader dr1 = conobj.fn_Reader(sel1);
                int pid = 0;
                decimal pq = 0;
                decimal tp = 0;
                while (dr1.Read())
                {
                    pid = Convert.ToInt32(dr1["product_id"]);
                    pq = Convert.ToDecimal(dr1["qauntity"]);
                    tp = Convert.ToInt32(dr1["total_price"]);
                 }
                string ins1 = "insert into order_tb values(" + pid + "," + Session["userid"] + "," + pq + "," + tp + ",'" + DateTime.Now.ToString("MM/dd/yyyy HH:MM:ss") + "','ordered')";
                int s = conobj.fn_nonquery(ins1);
                string dl = "delete from cart where product_id=" + pid + "and user_id=" + Session["userid"] + "";
                int p = conobj.fn_nonquery(dl);
                 }
            
            int x = Convert.ToInt32(Label6.Text);
            string ins = "insert into bill_tb values(" + Session["userid"] + "," + x + ",'" + DateTime.Now.ToString("MM/dd/yyyy HH:MM:ss") + "','ordered')";
            conobj.fn_nonquery(ins);
            Response.Redirect("bill.aspx");

        }
    }
}