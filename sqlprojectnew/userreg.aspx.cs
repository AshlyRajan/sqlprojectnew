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
    public partial class userreg : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                string sel = "select state_id,state_name from statelist";
                DataSet ds = conobj.fn_Dataset(sel);
                DropDownList1.DataSource = ds;
                DropDownList1.DataValueField = "state_id";
                DropDownList1.DataTextField = "state_name";
                DropDownList1.DataBind();

            }
        }
            protected void DropDownList1_TextChanged(object sender, EventArgs e)
            {
                if (DropDownList1.SelectedItem.Text == "kerala")
                {
                    string sel1 = "select dis_id,dis_name from district";
                    DataSet ds1 = conobj.fn_Dataset(sel1);
                    DropDownList2.DataSource = ds1;
                    DropDownList2.DataValueField = "dis_id";
                    DropDownList2.DataTextField = "dis_name";
                    DropDownList2.DataBind();
                }
                else if (DropDownList1.SelectedItem.Text == "tamilnadu")
                {
                    string sel1 = "select dis_id,dis_name from district";
                    DataSet ds1 = conobj.fn_Dataset(sel1);
                    DropDownList2.DataSource = ds1;
                    DropDownList2.DataValueField = "dis_id";
                    DropDownList2.DataTextField = "dis_name";
                    DropDownList2.DataBind();
                }
                else if (DropDownList1.SelectedItem.Text == "karnadaka")
                {
                    string sel1 = "select dis_id,dis_name from district";
                    DataSet ds1 = conobj.fn_Dataset(sel1);
                    DropDownList2.DataSource = ds1;
                    DropDownList2.DataValueField = "dis_id";
                    DropDownList2.DataTextField = "dis_name";
                    DropDownList2.DataBind();
                }

            }
                      

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string sel = "select max(Reg_id)from login";
            string Regid = conobj.fn_scalar(sel);
            int Reg_id = 0;
            if (Regid == "")
            {
                Reg_id = 1;
            }
            else
            {
                int newregid = Convert.ToInt32(Regid);
                Reg_id = newregid + 1;

            }
            string ins = "insert into user_reg values(" + Reg_id + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + DropDownList1.SelectedItem.Text + "','" + DropDownList2.SelectedItem.Text + "')";
            int i = conobj.fn_nonquery(ins);
            if (i == 1)
            {
                string inslog = "insert into login values(" + Reg_id + ",'" + TextBox6.Text + "','" + TextBox7.Text + "','user','active')";
                int j = conobj.fn_nonquery(inslog);
            }


        }

        
    }
}