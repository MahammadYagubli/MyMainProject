using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test
{
    public partial class Add_Holidays : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
          String secondsnstrn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\database\\mydb.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnection myConnection = new SqlConnection(secondsnstrn);// Binds the Data on the page
            SqlCommand myCommand = new SqlCommand("select date from [dbo].[holiday]",
                myConnection);
            myCommand.CommandType = CommandType.Text;
            // Opens a Database Connection
            myConnection.Open();
            // Execute DataReader
            SqlDataReader dr = myCommand.ExecuteReader();
            // Read DataReader till it reaches the end
            while (dr.Read() == true)
            {
                // Assign the Calendar control dates
                // already contained in the database
                Calendar1.SelectedDates.Add(dr.GetDateTime(0));
                Response.Write(dr.GetDateTime(0).ToShortDateString());
            }

            // Close DataReader
            dr.Close();
            // Close database Connection
            myConnection.Close();
 
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
  String secondsnstrn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\database\\mydb.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnection myConnection = new SqlConnection(secondsnstrn);// Binds the Data on the page

            // Set the color of Selected Calendar Cells to Red
            Calendar1.SelectedDayStyle.BackColor = System.Drawing.Color.Red;

            SqlCommand myCommand = new SqlCommand("CheckEmployeeId", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime));
            myCommand.Parameters.Add(new SqlParameter("@type", SqlDbType.VarChar));
            myCommand.Parameters["@date"].Value = Calendar1.SelectedDate.ToShortDateString();
            Response.Write(Calendar1.SelectedDate.ToShortDateString());
            myCommand.Parameters["@type"].Value = "Holyday";
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Record Inserted Successfully');", true);

            String secondsnstrn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\database\\mydb.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnection myConnection = new SqlConnection(secondsnstrn);// Binds the Data on the page

            // Set the color of Selected Calendar Cells to Red
            Calendar1.SelectedDayStyle.BackColor = System.Drawing.Color.Red;

            SqlCommand myCommand = new SqlCommand("deleterow", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime));
            myCommand.Parameters["@date"].Value = Calendar1.SelectedDate.ToShortDateString();
            
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            Response.Write("YOUR REQUIRE HAS BEEN CORRECTLY ACCEPTED");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/stuff.aspx");
        }
    }
}