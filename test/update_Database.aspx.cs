using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test
{
    public partial class update_Database : System.Web.UI.Page
    {
        int insertionCounterInLocalDatabase = 0;
        int insertionCounterInServerDatabase = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
         
            LocalSideDatabase();
            Response.Write("numberOfRowsinLocalDatabase"+ insertionCounterInLocalDatabase);
            ServersideDatabase();
            Response.Write("numberOfRowsInServerSideDatabase" + insertionCounterInServerDatabase);

        }
            public void LocalSideDatabase()
        { 
            int num = 1;
            //String secondsnstrn = "Data Source=appserver\\sqlexpress;Initial Catalog=vstlsft;Integrated Security=True";
          String secondsnstrn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\database\\mydb.mdf;Integrated Security=True;Connect Timeout=30";
            
           // string connStr = ConfigurationManager.ConnectionStrings["connection_3"].ToString();
            SqlConnection con = new SqlConnection(secondsnstrn);
            SqlCommand cmd = new SqlCommand();
            //con.Open();

            //  String data = drpdwnmonth.Items.IndexOf(drpdwnmonth.Items.FindByText(selectedmonth)) + "/" + selectedday + "/" + selectedyear + " 12:00:00 AM";
            // secondtype = drpdwnmonth.Items.IndexOf(drpdwnmonth.Items.FindByText(selectedmonth)) + "/" + selectedday + "/" + selectedyear;
            string SqlString = "SELECT * FROM tb_LockAuditTrail;";
            //string SqlString = "SELECT * FROM tb_LockAuditTrail where id_user='" + id + "';";
            SqlDataAdapter sda = new SqlDataAdapter(SqlString, con);
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                sda.Fill(dt);
            }
            catch (SqlException)
            {

            }
            finally
            {
                con.Close();
            }

            foreach (DataRow row in dt.Rows)

            {
                    //All the data from local database will be here
                insertionCounterInLocalDatabase = Convert.ToInt32(row[7].ToString()); 
                
            }
    

        }
            public void ServersideDatabase()
        {
            bool permitUpdate = false;
        String secondsnstrn = "Data Source=fs01\\sqlexpress;Initial Catalog=SALTO_RW;Integrated Security=True";
         //   SqlConnection con = new SqlConnection(secondsnstrn);
          //  string connStr = ConfigurationManager.ConnectionStrings["connection_1"].ToString();
            SqlConnection con = new SqlConnection(secondsnstrn);
            SqlCommand cmd = new SqlCommand();
            //con.Open();

            //  String data = drpdwnmonth.Items.IndexOf(drpdwnmonth.Items.FindByText(selectedmonth)) + "/" + selectedday + "/" + selectedyear + " 12:00:00 AM";
            // secondtype = drpdwnmonth.Items.IndexOf(drpdwnmonth.Items.FindByText(selectedmonth)) + "/" + selectedday + "/" + selectedyear;
            string SqlString = "SELECT * FROM tb_LockAuditTrail;";
            //string SqlString = "SELECT * FROM tb_LockAuditTrail where id_user='" + id + "';";
            SqlDataAdapter sda = new SqlDataAdapter(SqlString, con);
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                sda.Fill(dt);
            }
            catch (SqlException)
            {

            }
            finally
            {
                con.Close();
            }

            foreach (DataRow row in dt.Rows)

            {
                 
             //  All the data from Server database will be here;
                insertionCounterInServerDatabase = Convert.ToInt32(row[7].ToString());
              if (insertionCounterInServerDatabase == insertionCounterInLocalDatabase+1) {
                 permitUpdate = true;

                    }
            if (permitUpdate) {
                    Response.Write("Writiing to Database...........");
                    insert(row[0].ToString(), Convert.ToDateTime(row[1].ToString()),row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), Convert.ToInt32(row[7]));
       }

            }

                                 

        }
            public void insert(String id_event, DateTime dt_Audit, String InsertOrder, String id_lock, String id_user, String NCopy, String id_function, int InsertionCounter)
        {
           // String secondsnstrn = "Data Source=appserver\\sqlexpress;Initial Catalog=vstlsft;Integrated Security=True";
          String secondsnstrn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\database\\mydb.mdf;Integrated Security=True;Connect Timeout=30";
         //   SqlConnection con = new SqlConnection(secondsnstrn);
           // string connStr = ConfigurationManager.ConnectionStrings["connection_3"].ToString();
            SqlConnection con = new SqlConnection(secondsnstrn);
            SqlCommand cmd = new SqlCommand("insert into tb_LockAuditTrail (id_event,dt_Audit,InsertOrder,id_lock,id_user, NCopy,id_function,InsertionCounter) values('" + id_event + "','" + dt_Audit + "','" + InsertOrder + "','" + id_lock + "','" + id_user + "','" + NCopy + "','" + id_function + "','" + InsertionCounter + "')", con);

            cmd.CommandType = CommandType.Text;

            try

            {

                con.Open();

                int b = cmd.ExecuteNonQuery();

                Response.Write(b.ToString() + "rows are affected");

                con.Close();



            }

            catch (Exception ex)

            {

                Response.Write(ex.Message);

            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/stuff.aspx");
        }
    }
}