using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace test
{
    public class database_updater
    {

        int insertionCounterInLocalDatabase = 0;
        int insertionCounterInServerDatabase = 0;

        public database_updater() {

                LocalSideDatabase();
                ServersideDatabase();
                }
        public void LocalSideDatabase()
        {
            int num = 1;
            String secondsnstrn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\database\\mydb.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(secondsnstrn);
            SqlCommand cmd = new SqlCommand();
            //con.Open();

            //  String data = drpdwnmonth.Items.IndexOf(drpdwnmonth.Items.FindByText(selectedmonth)) + "/" + selectedday + "/" + selectedyear + " 12:00:00 AM";
            // secondtype = drpdwnmonth.Items.IndexOf(drpdwnmonth.Items.FindByText(selectedmonth)) + "/" + selectedday + "/" + selectedyear;
            string SqlString = "SELECT * FROM tb_LockAuditTrailer;";
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
                if (insertionCounterInServerDatabase == insertionCounterInLocalDatabase + 1)
                {
                    permitUpdate = true;
                }
                if (permitUpdate)
                {
                    insert(row[0].ToString(), Convert.ToDateTime(row[1].ToString()), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), Convert.ToInt32(row[7]));
                }

            }



        }
        public void insert(String id_event, DateTime dt_Audit, String InsertOrder, String id_lock, String id_user, String NCopy, String id_function, int InsertionCounter)
        {
            String secondsnstrn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\database\\mydb.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(secondsnstrn);
            SqlCommand cmd = new SqlCommand("insert into tb_LockAuditTrailer (id_event,dt_Audit,InsertOrder,id_lock,id_user, NCopy,id_function,InsertionCounter) values('" + id_event + "','" + dt_Audit + "','" + InsertOrder + "','" + id_lock + "','" + id_user + "','" + NCopy + "','" + id_function + "','" + InsertionCounter + "')", con);

            cmd.CommandType = CommandType.Text;

            try

            {

                con.Open();

                int b = cmd.ExecuteNonQuery();

                

                con.Close();



            }

            catch (Exception ex)
                        {

               

            }

        }

    }
}