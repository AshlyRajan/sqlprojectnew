using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sqlprojectnew
{
    public partial class admin : System.Web.UI.Page
    {
        Connection conobj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
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
            string ins = "insert into admin values(" + Reg_id + ",'" + TextBox1.Text + "','" + TextBox2.Text + "'," + TextBox3.Text + ",'" + TextBox4.Text + "')";
            int i = conobj.fn_nonquery(ins);
            if (i == 1)
            {
                string inslog = "insert into login values(" + Reg_id + ",'" + TextBox5.Text + "','" + TextBox6.Text + "','admin','active')";
                int j = conobj.fn_nonquery(inslog);
            }

        }
    }
}