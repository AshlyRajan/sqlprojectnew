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
    public partial class payment : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sel = "select grand_total from bill_tb where user_id=" + Session["userid"] + "and bill_status='ordered'";
            Session["total"] = conobj.fn_scalar(sel);
            Label1.Text = Session["total"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            paymentService1.ServiceClient ob = new paymentService1.ServiceClient();
            int bal = ob .acc_bal(Convert.ToInt32(TextBox1.Text));
            int gt = Convert.ToInt32(Session["total"]);
            if (bal >= gt)
            {
                string sel4 = "select max(Account_id) from account_tb where user_id=" + Session["userid"] + "";
                string maid = conobj.fn_scalar(sel4);
                int aid = Convert.ToInt32(maid);
                decimal newbal = bal - gt;
                string up = "update account_tb set Balance_amt=" + newbal + ",status='Deactive' where account_id=" + aid + "";
                int i = conobj.fn_nonquery(up);
                if (i == 1)
                {
                    string sel = "select order_id from order_tb where user_id=" + Session["userid"] + " and order_status='Ordered'";
                    List<int> olis = new List<int>();
                    SqlDataReader dr2 = conobj.fn_Reader(sel);
                    while (dr2.Read())
                    {
                        olis.Add(Convert.ToInt32(dr2["Order_Id"]));
                    }
                    foreach (int k in olis)
                    {
                        string up1 = "update order_tb set order_status='Paid' where order_id=" + k + "";
                        conobj.fn_nonquery(up1);
                    }
                    string sel1 = "select max(Bill_id) from bill_tb where user_id=" + Session["userid"] + " ";
                    string bid = conobj.fn_scalar(sel1);
                    string up2 = "update bill_tb set bill_status='Paid' where Bill_id=" + bid + "";
                    conobj.fn_nonquery(up2);
                    string sel2 = "select product_id from order_tb where order_status='Paid' and user_id=" + Session["userid"] + "";
                    List<int> plis = new List<int>();
                    SqlDataReader dr = conobj.fn_Reader(sel2);
                    while (dr.Read())
                    {
                        plis.Add(Convert.ToInt32(dr["product_id"]));
                    }
                    foreach (int j in plis)
                    {
                        string sel3 = "SELECT dbo.product_tb.product_stock, dbo.order_tb.quantity FROM dbo.product_tb INNER JOIN dbo.order_tb ON dbo.product_tb.product_id = dbo.order_tb.product_id where order_tb.product_id=" + j + " and User_id=" + Session["userid"] + "";
                        SqlDataReader dr1 = conobj.fn_Reader(sel3);
                        decimal ps = 0;
                        decimal qua = 0;
                        while (dr1.Read())
                        {
                            ps = Convert.ToDecimal(dr1["product_stock"]);
                            qua = Convert.ToDecimal(dr1["quantity"]);
                        }
                        decimal newst = ps - qua;
                        string newpst = newst.ToString();
                        string up3 = "update product_tb set product_stock='" + newpst + "' where product_id=" + j + "";
                        int k = conobj.fn_nonquery(up3);
                        if (k == 1)
                        {
                            Label2.Text = "Successfully Paid";
                        }
                    }
                }

            }
            else
            {
                Label2.Text = "Insufficient Balance";

                string sel4 = "select max(Account_id) from account_tb where user_id=" + Session["userid"] + "";
                string maid = conobj.fn_scalar(sel4);
                int aid = Convert.ToInt32(maid);
                decimal newbal = bal - gt;
                string up = "update account_tb set status='Deactive' where Account_id=" + aid + "";
                int i = conobj.fn_nonquery(up);
                if (i == 1)
                {
                    string sel = "select order_id from order_tb where user_id=" + Session["userid"] + " and order_status='Ordered'";
                    List<int> olis = new List<int>();
                    SqlDataReader dr2 = conobj.fn_Reader(sel);
                    while (dr2.Read())
                    {
                        olis.Add(Convert.ToInt32(dr2["order_id"]));
                    }
                    foreach (int k in olis)
                    {
                        string up1 = "update order_tb set order_status='Cancelled' where order_id=" + k + "";
                        conobj.fn_nonquery(up1);
                    }
                    string sel1 = "select max(Bill_id) from bill_tb where user_id=" + Session["userid"] + " ";
                    string bid = conobj.fn_scalar(sel1);
                    string up2 = "update bill_tb set bill_status='Failed' where Bill_id=" + bid + "";
                    conobj.fn_nonquery(up2);
                }

            }
        }
            }
        }
    