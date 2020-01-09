using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsGuru
{
    public partial class Demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ConnectionToDb();

            //ConnectionToDbWithAdapterToInsert();
            ConnectionToDbToUpdate();

            ConnectionToDbToDelete("u2");

            ConnectionToDbWithReader();

            //ForceToSeeDefaultErrorPage();

            CuriosityOfPlusPlus();
        }

        private void CuriosityOfPlusPlus()
        {
            int c = 7;
            int k = 7;
            Response.Write("c:");
            Response.Write(c++);
            Response.Write("k:");
            Response.Write(++k);
            Response.Write(">c:");
            Response.Write(c);
            Response.Write(">k:");
            Response.Write(k);
        }

        private void ForceToSeeDefaultErrorPage()
        {
            string path = @"D:\Example.txt";
            string[] lines;
            lines = File.ReadAllLines(path);
        }

        private void ConnectionToDbToDelete(string userId)
        {
            string cx = ConfigurationManager.ConnectionStrings["cxToCamaleonCore"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cx);
            cnn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = String.Format("DELETE TestTableOfUsers WHERE UserId LIKE '{0}%'", userId);

            command = new SqlCommand(sql, cnn);

            adapter.DeleteCommand = new SqlCommand(sql, cnn);
            adapter.DeleteCommand.ExecuteNonQuery();

            command.Dispose();
            cnn.Close();
        }

        private void ConnectionToDbToUpdate()
        {
            string cx = ConfigurationManager.ConnectionStrings["cxToCamaleonCore"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cx);
            cnn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";

            sql = "UPDATE TestTableOfUsers SET UserName='Alo' WHERE UserId LIKE 'u4%'";

            command = new SqlCommand(sql, cnn);

            adapter.UpdateCommand = new SqlCommand(sql, cnn);
            adapter.UpdateCommand.ExecuteNonQuery();

            command.Dispose();
            cnn.Close();
        }

        private void ConnectionToDbWithAdapterToInsert()
        {
            string cx = ConfigurationManager.ConnectionStrings["cxToCamaleonCore"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cx);
            cnn.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";

            sql = "INSERT INTO TestTableOfUsers (UserId, UserName) VALUES('u6', 'Juan')";

            command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = new SqlCommand(sql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();

            command.Dispose();
            cnn.Close();
        }

        private void ConnectionToDbWithReader()
        {
            string cx = ConfigurationManager.ConnectionStrings["cxToCamaleonCore"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cx);
            cnn.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            string sql = "SELECT UserId, UserName from TestTableOfUsers";

            command = new SqlCommand(sql, cnn);

            dataReader = command.ExecuteReader();
            StringBuilder sb = new StringBuilder();
            while (dataReader.Read())
            {
                sb.Append(dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + "</br>");
            }

            Response.Write(sb.ToString() + "<br>");
            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }

        private void ConnectionToDb()
        {
            string cx = ConfigurationManager.ConnectionStrings["cxToCamaleonCore"].ConnectionString;
            SqlConnection cnn = new SqlConnection(cx);

            cnn.Open();

            Response.Write("Connection Made.<br>");
            cnn.Close();
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