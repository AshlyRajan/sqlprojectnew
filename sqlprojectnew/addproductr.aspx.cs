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
    public partial class addorder : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridbind_fun();
            
            
                string sel = "select category_id,category_name from category";
                DataSet ds = conobj.fn_Dataset(sel);
                DropDownList1.DataSource = ds;
                DropDownList1.DataValueField = "category_id";
                DropDownList1.DataTextField = "category_name";
                DropDownList1.DataBind();
            }
            
        }
            public void gridbind_fun()
            {
                string sel = "select * from product_tb";
                DataSet ds = conobj.fn_Dataset(sel);
                GridView1.DataSource = ds;
                GridView1.DataBind();

            }
                              
             protected void Button1_Click(object sender, EventArgs e)
        {

            string path = "~/ORDER/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(path));
            string ins = "insert into product_tb values(" + DropDownList1.SelectedItem.Value + ",'" + TextBox5.Text + "'," + TextBox2.Text + ",'" + TextBox3.Text + "','" + path + "','" + TextBox4.Text + "')";
            int i = conobj.fn_nonquery(ins);
        }
                  
                protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gridbind_fun();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            FileUpload f1 = (FileUpload)GridView1.Rows[i].Cells[3].FindControl("fileupload2");
            string p = "~/category/" + f1.FileName;
            f1.SaveAs(MapPath(p));
            TextBox txtdecription = (TextBox)GridView1.Rows[i].Cells[4].FindControl("TextBox4");
            string strup = "update category set category_image='" + p + "',category_description='" + txtdecription.Text + "'where category_id=" + getid + "";
            int j = conobj.fn_nonquery(strup);
            GridView1.EditIndex = -1;
            gridbind_fun();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gridbind_fun();
        }

                protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            string del = "delete from product_tb where product_id=" + getid + "";
            int j = conobj.fn_nonquery(del);
            gridbind_fun();
        }
        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {

        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

    }
}