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
    
    public partial class stuff : System.Web.UI.Page
    {
           
        DataTable fire = new DataTable();
        DataTable table = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Visible = false;
            if (!IsPostBack)
            {
                Session["stuffname"] = "guest";
                Session["stuffsurname"] = "guest";
                String secondsnstrn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\database\\mydb.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection con = new SqlConnection(secondsnstrn);
                //  String data = drpdwnmonth.Items.IndexOf(drpdwnmonth.Items.FindByText(selectedmonth)) + "/" + selectedday + "/" + selectedyear + " 12:00:00 AM";
                // secondtype = drpdwnmonth.Items.IndexOf(drpdwnmonth.Items.FindByText(selectedmonth)) + "/" + selectedday + "/" + selectedyear;
                string SqlString = "SELECT * FROM stuff;";
                //string SqlString = "SELECT * FROM tb_LockAuditTrail where id_user='" + id + "';";
                SqlDataAdapter sa = new SqlDataAdapter(SqlString, con);
                try
                {

                    con.Open();
                    sa.Fill(fire);

                }
                catch (SqlException)
                {

                }
                finally
                {
                    con.Close();

                }

                foreach (DataRow bye in fire.Rows)

                {

                    ListItem item = new ListItem(bye[1].ToString() + " " + bye[2].ToString(), bye[1].ToString() + " " + bye[2].ToString(),true);
                    
                    // insert(row[3].ToString(),row[4].ToString(),"stuff","0","0","0");
                    if (bye[6].ToString() == "0")
                    {
                        item.Attributes.Add("style", "background-color:red;");
                    }
                    else if (bye[6].ToString() != "0")
                    {
                        item.Attributes.Add("style", "background-color:green;");

                    }
                    DropDownList5.Items.Add(item);
                }
                Response.Write("It is not postback");
            }
            else {
                Response.Write("It is postback");
            }
          
              }
          
        public void Insert(String Name, String Surname, String Status, String Id_user, String NCopy)
        {
            // String secondsnstrn = "Data Source=appserver\\sqlexpress;Initial Catalog=vstlsft;Integrated Security=True";
            String secondsnstrn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\database\\mydb.mdf;Integrated Security=True;Connect Timeout=30";
            //   SqlConnection con = new SqlConnection(secondsnstrn);
            // string connStr = ConfigurationManager.ConnectionStrings["connection_3"].ToString();
            SqlConnection con = new SqlConnection(secondsnstrn);
            SqlCommand cmd = new SqlCommand("insert into stuff (Name,Surname, Status ,Id_user, Ncopy) values('" + Name + "','" + Surname + "','" + Status + "','" + Id_user + "','" + NCopy + "')", con);

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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel_update.Visible = true;
            Panel_search.Visible = true;
            btnaddnew.BackColor = System.Drawing.Color.OrangeRed;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Panel_search.Visible = false;
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            Panel_update.Visible = true;
            btnaddnew.BackColor = System.Drawing.Color.Green;
             

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            if (Convert.ToInt32(findneededperson((TextBox6.Text + " " + TextBox7.Text))) == 1) {
                Label1.Text="Successfully found";
               btnupdatenow.Visible = true;

            }
            else {
                  Label1.Text="Please check corectness";
                btnupdatenow.Visible = false;
            }
                 

             
        }

        
      public void Checkifthenameisexistindatabase(String name, String surname)
        {
            String secondsnstrn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\database\\mydb.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(secondsnstrn);
            SqlCommand cmd = new SqlCommand();
            string SqlString = "SELECT * FROM stuff where Name='" + name + "'AND Surname='" + surname + "';";
            SqlDataAdapter sada = new SqlDataAdapter(SqlString, con);
             table = new DataTable();
            try
            {
                con.Open();
                sada.Fill(table);
            }
            catch (SqlException)
            {

            }
            finally
            {
                con.Close();
            }
            Boolean exist = false;
            foreach (DataRow row in table.Rows)
            {
                if (row[1].ToString().Equals(name)) {
                    Response.Write("Name is true");
                    if (row[2].ToString().Equals(surname))
                    {
                        Response.Write("SURName is true");
                        exist = true;
                        Label1.Text = "this name is in our database";
                        btnupdatenow.Visible = true;
                        TextBox1.Text = row[1].ToString();
                        TextBox2.Text = row[2].ToString();
                        DropDownList1.SelectedValue = row[3].ToString();
                        TextBox4.Text = row[4].ToString();
                        TextBox5.Text = row[5].ToString();

                    }

                }
            }
            if (exist == false) {

                Label1.Text = "this name is not in our database";
            }

        }

        protected void btnupdatenow_Click(object sender, EventArgs e)
        {
            if (btnupdatenow.Visible) {
                 findneededperson((TextBox6.Text + " " + TextBox7.Text).ToString());
                  Panel_update.Visible = true;
                Button1.Visible = true;
            }
           
            Panel2.Visible = false;
            
        }
  
      
        public void insertion(String Name, String Surname, String Status, String Id_user, String Ncopy, String asign)
        {
            String secondsnstrn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\database\\mydb.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection(secondsnstrn);
            SqlCommand cmd = new SqlCommand("insert into stuff (Name,Surname,Status,Id_user,Ncopy, asign) values('" + Name + "','" + Surname + "','" + Status + "','" + Id_user + "','" + Ncopy + "','" + asign + "')", conn);
            cmd.CommandType = CommandType.Text;
            try
            {
                conn.Open();
                int b = cmd.ExecuteNonQuery();
                Response.Write(b.ToString() + "rows are affected");
                conn.Close();
           }

            catch (Exception ex)

            {

                Response.Write(ex.Message);

            }

        }
        public void update(String Name, String Surname)
        {
            if (!Panel_update.Visible) {
                Panel_update.Visible = true;
            }
              // String secondsnstrn = "Data Source=appserver\\sqlexpress;Initial Catalog=vstlsft;Integrated Security=True";
              String secondsnstrn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\database\\mydb.mdf;Integrated Security=True;Connect Timeout=30";
            //   SqlConnection con = new SqlConnection(secondsnstrn);
            // string connStr = ConfigurationManager.ConnectionStrings["connection_3"].ToString();
            SqlConnection coon = new SqlConnection(secondsnstrn);

            SqlDataAdapter da = new SqlDataAdapter();
            da.UpdateCommand = new SqlCommand("UPDATE stuff SET Name = @name, Surname = @surname, Status= @status, Id_user=@id_user, Ncopy=@ncopy, asign=@asign where Name='" + Name + "'AND Surname='" + Surname + "'", coon);
            da.UpdateCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = TextBox1.Text ;
            da.UpdateCommand.Parameters.Add("@surname", SqlDbType.VarChar).Value =  TextBox2.Text ;
            da.UpdateCommand.Parameters.Add("@status", SqlDbType.VarChar).Value =  DropDownList1.SelectedItem.Value;
            da.UpdateCommand.Parameters.Add("@id_user", SqlDbType.VarChar).Value = TextBox4.Text;
            da.UpdateCommand.Parameters.Add("@ncopy", SqlDbType.VarChar).Value = TextBox5.Text;
            da.UpdateCommand.Parameters.Add("@asign", SqlDbType.VarChar).Value = "a";
            coon.Open();
            da.UpdateCommand.ExecuteNonQuery();
            coon.Close();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "" || TextBox2.Text == "" ||
             TextBox4.Text == "" || TextBox5.Text == "" || DropDownList1.SelectedValue == "-1")
            {
                Response.Write("Please fill all mandatory fields");
            }
            //TextBox1.Text = DropDownList1.SelectedValue;
            // insert(TextBox1.Text, TextBox2.Text, DropDownList1.SelectedValue, TextBox4.Text, TextBox5.Text);
            else
            {
                update(Session["stuffname"].ToString(), Session["stuffsurname"].ToString());
                Response.Write("Given data Succesfully Added");

            }
        }
     protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
     protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button1.Visible = true;
            findneededperson(DropDownList5.SelectedValue.ToString());
            Panel_search.Visible = false;
            Panel_update.Visible = true;
        }

        public int findneededperson(String neededperson) {
           


            //  Response.Write(DropDownList3.SelectedItem.Value.ToString());
            String secondsnstrn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\database\\mydb.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(secondsnstrn);
            //  String data = drpdwnmonth.Items.IndexOf(drpdwnmonth.Items.FindByText(selectedmonth)) + "/" + selectedday + "/" + selectedyear + " 12:00:00 AM";
            // secondtype = drpdwnmonth.Items.IndexOf(drpdwnmonth.Items.FindByText(selectedmonth)) + "/" + selectedday + "/" + selectedyear;
            string SqlString = "SELECT * FROM stuff;";
            //string SqlString = "SELECT * FROM tb_LockAuditTrail where id_user='" + id + "';";
            SqlDataAdapter sa = new SqlDataAdapter(SqlString, con);
            DataTable mytable = new DataTable() { };
            try
            {

                con.Open();
                sa.Fill(mytable);

            }
            catch (SqlException)
            {

            }
            finally
            {
                con.Close();

            }



            foreach (DataRow row in mytable.Rows)

            {

                if (row[1].ToString() + " " + row[2].ToString() == neededperson)
                {
                   
                    TextBox1.Text = row[1].ToString();
                    TextBox2.Text = row[2].ToString();
                    TextBox4.Text = row[4].ToString();
                    TextBox5.Text = row[5].ToString();
                    Session["id_user"]=row[4].ToString();
                    Session["ncopy"]=row[5].ToString();
                    Session["stuffname"] = row[1].ToString();
                    Session["stuffsurname"] = row[2].ToString();
                    return 1;
                }
            }
            return 2;

        }

        protected void chosefromlist_Click(object sender, EventArgs e)
        {
            Session["id_user"] = "0";
            Session["ncopy"] = "0";
            DropDownList5.Visible = true;
           Panel_update.Visible = false;
            Panel_search.Visible = false;
            Panel2.Visible = true;
        }

        protected void seachmanually_Click(object sender, EventArgs e)
        {
            Session["id_user"] = "0";
            Session["ncopy"] = "0";
            DropDownList5.Visible = false;
        Panel_update.Visible = false;
        Panel_search.Visible = true;
            Panel2.Visible = false;
           
        }

        protected void addnewstuff_Click(object sender, EventArgs e)
        {
            Session["id_user"] = "0";
            Session["ncopy"] = "0";
            Panel_search.Visible = false;
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            Panel_update.Visible = true;
            btnaddnew.BackColor = System.Drawing.Color.Green;

          
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (Button1.Visible) {
                if (Session["id_user"].ToString() != "0" && Session["ncopy"].ToString() != "0")
                {
                    Server.Transfer("~/Home.aspx");

                }
                else {

                    Label2.Visible = true;
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/update_Database.aspx");
        }

        protected void main_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Home.aspx");
        }
    }
    }
   
     

