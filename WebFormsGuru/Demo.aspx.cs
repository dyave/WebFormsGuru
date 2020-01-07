using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsGuru
{
    public partial class Demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ActionToHide();
        }

        private void ActionToHide()
        {
            Response.Write("<hr style='margin-left: 10px;' />");
            Session["Name"] = txtName.Text;
            Response.Write(Session["Name"]);
            Response.Write("<hr style='margin-left: 10px;' />");

            Response.Write(txtName.Text + "</br>");
            Response.Write(lstLocation.SelectedItem.Text + "</br>");

            lblName.Visible = false;
            txtName.Visible = false;
            lstLocation.Visible = false;
            chkC.Visible = false;
            chkASP.Visible = false;
            rdMale.Visible = false;
            rdFemale.Visible = false;
            btnSubmit.Visible = false;
        }
    }
}