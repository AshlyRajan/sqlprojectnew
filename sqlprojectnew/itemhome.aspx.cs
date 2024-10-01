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
    public partial class itemhome : System.Web.UI.Page

    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sel = "select * from product_tb where product_id=" + Session["product_id"] + "";
                SqlDataReader dr = conobj.fn_Reader(sel);
                while (dr.Read())
                {
                    Label1.Text = dr["product_name"].ToString();
                    Label2.Text = dr["product_price"].ToString();
                    Label3.Text = dr["product_stock"].ToString();
                    TextBox4.Text = dr["product_description"].ToString();
                    Image1.ImageUrl = dr["product_img"].ToString();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select max(cart_id)from cart";
            string i = conobj.fn_scalar(sel);
            int cart_id = 0;
            if (i == "")
            {
                cart_id = 1;
            }
            else
            {
                int newregid = Convert.ToInt32(i);
                cart_id = newregid + 1;

            }
            decimal p = Convert.ToDecimal(Label2.Text); 
            decimal q = Convert.ToDecimal(TextBox5.Text);//quantity
            decimal pp = p * q;
            string ins = "insert into cart values(" + cart_id + "," + Session["userid"] + ","+ Session["product_id"] + ","+q+","+pp+",'"+DateTime .Now.ToString ("MM/dd/yyyy HH:MM:ss") +"')"; 
            int j = conobj.fn_nonquery(ins);
        }
    }
}