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
    public partial class WebForm1 : System.Web.UI.Page
    {
        DateTime date;
        DataTable dat = new DataTable();
        DataTable holidays = new DataTable();
        String entrytime = "0";
        String exittime = "0";
        String workload = "";
        int numberOfDays = 0;
        int holidaysinworkingdays = 0;
        int totalHour;
        int totalMinute;
        int totalSeconds;
        String[] substrings;
        int id = 42;
        int Ncopy = 27;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id_user"] != null && Session["ncopy"] != null)
            {
                id = Convert.ToInt32(Session["id_user"]);
                Ncopy = Convert.ToInt32(Session["ncopy"]);
            }
            if (!IsPostBack)
            {
                 LinkButton2.Visible = true;
               //if (Application["user_name"].ToString() == "mahammad" && Application["password"].ToString() == "mahammad")
               // {
                   //this line of code willl be used to differenciateadmin and users
              //  }

                if (dat.Rows.Count > 1) { Response.Write("I have more than one row"); }

                else if (dat.Rows.Count < 1)
                {

                    //  String secondsnstrn = "Data Source=fs01\\sqlexpress;Initial Catalog=SALTO_RW;Integrated Security=True";
                    String secondsnstrn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\database\\mydb.mdf;Integrated Security=True;Connect Timeout=30";
                    //String secondsnstrn = "Data Source=appserver\\sqlexpress;Initial Catalog=vstlsft;Integrated Security=True";
                    // SqlConnection con = new SqlConnection(secondsnstrn);
                    //  string connStr = ConfigurationManager.ConnectionStrings["connection_3"].ToString();
                    SqlConnection con = new SqlConnection(secondsnstrn);
                    SqlCommand cmd = new SqlCommand();
                    if (Session["id_user"] != null && Session["ncopy"] != null)
                    {
                        id = Convert.ToInt32(Session["id_user"]);
                        Ncopy = Convert.ToInt32(Session["ncopy"]);
                    }
                    string SqlString = "SELECT * FROM tb_LockAuditTrail where id_user='" + id + "'AND NCopy='" + Ncopy + "';";

                    SqlDataAdapter sda = new SqlDataAdapter(SqlString, con);
                    try
                    {
                        con.Open();
                        sda.Fill(dat);
                    }
                    catch (SqlException)
                    {

                    }
                    finally
                    {
                        con.Close();
                    }

                }


            }
        }

        public void setidandNcopy(int sid, int sncopy)
        {
            id = sid;
            Ncopy = sncopy;
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            year.Visible = true;
            month.Visible = true;
        }
        protected void Stuff_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/stuff.aspx");
        }

        protected void view_Click(object sender, EventArgs e)
        {
            Response.Write("View has been clicked");
        }

        protected void Addperson_Click(object sender, EventArgs e)
        {
            Response.Write("~/stuff.aspx");
        }
        protected void Addholidays_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Add_Holidays.aspx");
        }

        protected void managaecalendar_Click(object sender, EventArgs e)
        {
            Response.Write("Manage calendar has been clicked");
        }
        public void mymethod(String id, String Ncopy, DateTime date, String dayofweek, DateTime today)
        {
            workload = "";
            int year = date.Year;
            int count = 0;
            String givendate = date.ToShortDateString();
            int result = DateTime.Compare(date, today);
            String selecteddate = date.ToShortTimeString().ToString();
            entrytime = "0";
            exittime = "0";
            TableRow newrows = new TableRow();
            TableCell Date = new TableCell();
            TableCell Day = new TableCell();
            TableCell Entry = new TableCell();
            TableCell Exit = new TableCell();
            TableCell Total = new TableCell();
            TableCell Timediff = new TableCell();

            if (dat.Rows.Count < 1)
            {

                //String secondsnstrn = "Data Source=fs01\\sqlexpress;Initial Catalog=SALTO_RW;Integrated Security=True";
                String secondsnstrn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\database\\mydb.mdf;Integrated Security=True;Connect Timeout=30";
                // appserver sqlexpress
                // String secondsnstrn = "Data Source=appserver\\sqlexpress;Initial Catalog=vstlsft;Integrated Security=True";
                // string secondsnstrn = ConfigurationManager.ConnectionStrings["connection_3"].ToString();
                //  SqlConnection con = new SqlConnection(connStr);
                SqlConnection con = new SqlConnection(secondsnstrn);
                SqlCommand cmd = new SqlCommand();
                if (Session["id_user"] != null && Session["ncopy"] != null)
                {
                    id = Session["id_user"].ToString();
                    Ncopy = Session["ncopy"].ToString();
                }
                string SqlString = "SELECT * FROM tb_LockAuditTrail where id_user='" + id + "'AND NCopy='" + Ncopy + "';";
                SqlDataAdapter sda = new SqlDataAdapter(SqlString, con);
                try
                {
                    con.Open();
                    sda.Fill(dat);
                }
                catch (SqlException)
                {

                }
                finally
                {
                    con.Close();
                }

            }





            if (result < 0)
            {


                int insertionvounter;
                foreach (DataRow row in dat.Rows)
                {


                    insertionvounter = Convert.ToInt32(row[7].ToString());
                    if (year == 2018 && insertionvounter >= 2643800)
                    {
                        String st = row[1].ToString();
                        Char delimiter = ' ';
                        substrings = st.Split(delimiter);
                        String dateofdatetime = substrings[0];
                        if (givendate == dateofdatetime)
                        {

                            count += 1;
                            if (entrytime == "0")
                            {

                                entrytime = row[1].ToString();
                                Date.Text = givendate;
                                Day.Text = dayofweek;
                                Entry.Text = entrytime;
                            }
                            exittime = row[1].ToString();
                            Exit.Text = exittime;
                            Total.Text = "ttt";
                            Timediff.Text = "ytttt";


                            //  calculateWorkingHours();

                            // datext=Convert.ToDateTime(row[1]); 


                            //TimeSpan diff = datext.Subtract(dateentry);
                            //TextBox1.Text = diff.ToString();

                        }
                        else
                        {
                            continue;
                        }

                    }
                    if (year == 2014)
                    {
                        String st = row[1].ToString();
                        Char delimiter = ' ';
                        substrings = st.Split(delimiter);
                        String dateofdatetime = substrings[0];
                        if (givendate == dateofdatetime)
                        {

                            count += 1;
                            if (entrytime == "0")
                            {
                                entrytime = row[1].ToString();
                                Date.Text = givendate;
                                Day.Text = dayofweek;
                                Entry.Text = entrytime;
                            }
                            exittime = row[1].ToString();
                            Exit.Text = exittime;
                            Total.Text = "ttt";
                            Timediff.Text = "ytttt";

                        }
                        if (insertionvounter == 83086)
                        {
                            break;
                        }
                    }

                    if (year == 2015 && insertionvounter >= 83086)
                    {
                        String st = row[1].ToString();
                        Char delimiter = ' ';
                        substrings = st.Split(delimiter);
                        String dateofdatetime = substrings[0];
                        if (givendate == dateofdatetime)
                        {

                            count += 1;
                            if (entrytime == "0")
                            {
                                Response.Write("Count!=0");
                                entrytime = row[1].ToString();
                                Date.Text = givendate;
                                Day.Text = dayofweek;
                                Entry.Text = entrytime;
                            }
                            exittime = row[1].ToString();
                            Exit.Text = exittime;
                            Total.Text = "ttt";
                            Timediff.Text = "ytttt";


                            //  calculateWorkingHours();

                            // datext=Convert.ToDateTime(row[1]); 


                            //TimeSpan diff = datext.Subtract(dateentry);
                            //TextBox1.Text = diff.ToString();

                        }
                        if (insertionvounter == 637871)
                        {
                            break;
                        }
                    }
                    if (year == 2016 && insertionvounter >= 637871)
                    {
                        String st = row[1].ToString();
                        Char delimiter = ' ';
                        substrings = st.Split(delimiter);
                        String dateofdatetime = substrings[0];
                        if (givendate == dateofdatetime)
                        {

                            count += 1;
                            if (entrytime == "0")
                            {
                                Response.Write("Count!=0");
                                entrytime = row[1].ToString();
                                Date.Text = givendate;
                                Day.Text = dayofweek;
                                Entry.Text = entrytime;
                            }
                            exittime = row[1].ToString();
                            Exit.Text = exittime;
                            Total.Text = "ttt";
                            Timediff.Text = "ytttt";


                            //  calculateWorkingHours();

                            // datext=Convert.ToDateTime(row[1]); 


                            //TimeSpan diff = datext.Subtract(dateentry);
                            //TextBox1.Text = diff.ToString();

                        }
                        if (insertionvounter == 1489131)
                        {
                            break;
                        }


                    }
                    if (year == 2017 && insertionvounter >= 1489131)
                    {
                        String st = row[1].ToString();
                        Char delimiter = ' ';
                        substrings = st.Split(delimiter);
                        String dateofdatetime = substrings[0];
                        if (givendate == dateofdatetime)
                        {

                            count += 1;
                            if (entrytime == "0")
                            {

                                entrytime = row[1].ToString();
                                Date.Text = givendate;
                                Day.Text = dayofweek;
                                Entry.Text = entrytime;
                            }
                            exittime = row[1].ToString();
                            Exit.Text = exittime;
                            Total.Text = "ttt";
                            Timediff.Text = "ytttt";


                            //  calculateWorkingHours();

                            // datext=Convert.ToDateTime(row[1]); 


                            //TimeSpan diff = datext.Subtract(dateentry);
                            //TextBox1.Text = diff.ToString();

                        }

                        if (insertionvounter == 2643800)
                        {
                            break;
                        }


                    }


                    //int counter = Convert.ToInt32(row[7.ToString()]);

                }
                if (count == 0 && dayofweek != "Saturday" && dayofweek != "Sunday")
                {

                    exittime = "2018-04-07 08:27:48.000";
                    entrytime = "2018-04-07 08:27:48.000";
                    Date.Text = givendate;
                    Day.Text = dayofweek;
                    Entry.Text = "Absence";
                    Exit.Text = "Absence";
                    Total.Text = "0";
                    Timediff.Text = "0";

                    if (thisdayholiday(date)) {
                        Date.Text = date.ToShortDateString();
                        Entry.Text = "Holiday";
                        Exit.Text = "Holiday";
                        holidaysinworkingdays += 1;
                    }
                    newrows.BackColor = System.Drawing.Color.AntiqueWhite;
                    newrows.Cells.Add(Date);
                    newrows.Cells.Add(Day);
                    newrows.Cells.Add(Entry);
                    newrows.Cells.Add(Exit);
                    newrows.Cells.Add(Total);
                    newrows.Cells.Add(Timediff);
                    Table1.Rows.Add(newrows);
                }
                if ((count == 0 && dayofweek == "Saturday") || (count == 0 && dayofweek == "Sunday"))
                {

                    newrows.BackColor = System.Drawing.Color.DarkMagenta;

                    Date.Text = date.ToShortDateString();
                    Day.Text = dayofweek;
                    exittime = "2018-04-07 08:27:48.000";
                    entrytime = "2018-04-07 08:27:48.000";
                    Entry.Text = "------";
                    Exit.Text = "------";
                    Total.Text = "0";
                    Timediff.Text = "0";
                    newrows.Cells.Add(Date);
                    newrows.Cells.Add(Day);
                    newrows.Cells.Add(Entry);
                    newrows.Cells.Add(Exit);
                    newrows.Cells.Add(Total);
                    newrows.Cells.Add(Timediff);
                    Table1.Rows.Add(newrows);

                }
                Total.Text = "0";
                if (!(count == 0 && dayofweek == "Saturday") || (count == 0 && dayofweek == "Sunday"))
                {
                    Total.Text = calculateWorkingHours(Convert.ToDateTime(entrytime), Convert.ToDateTime(exittime));
                }


                Timediff.Text = workload;
                newrows.Cells.Add(Date);
                newrows.Cells.Add(Day);
                newrows.Cells.Add(Entry);
                newrows.Cells.Add(Exit);
                newrows.Cells.Add(Total);
                newrows.Cells.Add(Timediff);
                Table1.Rows.Add(newrows);

            }
        }
        public void Clear()
        {
            entrytime = "0";
            exittime = "0";
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
                Table1.Visible = false;
                Table2.Visible = false;
            }
            else
            {
                Calendar1.Visible = true;
                SHOWHOLIDAYS();

            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            SetHolidaysData();
            Table1.Visible = true;
            Table2.Visible = false;
            DateTime today = DateTime.Now.Date;
            int daysnumber = 0;
            foreach (DateTime selecteddate in Calendar1.SelectedDates)
            {
                //   getholidaydates(selecteddate);
                //  Response.Write(selecteddate.ToString());
                daysnumber += 1;
                String b = selecteddate.DayOfWeek.ToString();
                date = selecteddate.Date;
                mymethod("54", "0", date, b, today);
            }
            if (daysnumber == 1) {
                numberOfDays = 1;
            }
            if (daysnumber == 7)
            {
                numberOfDays = 5 - holidaysinworkingdays;
            }
            if (daysnumber > 7) {
                numberOfDays = 20 - holidaysinworkingdays;
            }

            createNewTableRow("Conslusion", calculateDifference(totalHour, totalMinute, totalSeconds, numberOfDays), calculateTotalDifference(0, 0, 0), numberOfDays);
            workload = calculateDifference(totalHour, totalMinute, totalSeconds, numberOfDays);
            totalHour = 0;
            totalMinute = 0;
            totalSeconds = 0;
            Calendar1.SelectedDates.Clear();
        }
        public String calculateWorkingHours(DateTime ent, DateTime ext)
        {


            var diff = ext.Subtract(ent);
            if (diff.Hours == 0 && diff.Minutes == 0)
            {

                return "0";
            }
            String difference = String.Format("{0}:{1}:{2}", diff.Hours, diff.Minutes, diff.Seconds);

            CalculateTotalWorkingHours(diff.Hours, diff.Minutes, diff.Seconds);
            workload = calculateDifference(diff.Hours, diff.Minutes, diff.Seconds, 1);

            return difference;
        }
        public String calculateDifference(int hour, int minute, int second, int day)
        {
            int wrkld = day * 8;
            String minus = "";
            if (day == 1)
            {

                if (hour >= 8)
                {
                    hour = hour - 8;
                }
                else
                {
                    hour = 7 - hour;
                    minute = 59 - minute;
                    second = 60 - second;
                    if (second == 60)
                    {
                        minute = minute + 1;
                        second = 0;
                    }
                    if (minute == 60)
                    {
                        hour = hour + 1;
                        minute = 0;
                    }

                    minus = "-";

                }

            }
            if (day > 1 && day < 7)
            {
                if (hour >= wrkld)
                {

                    hour = hour - wrkld;

                }
                else
                {
                    hour = (wrkld - 1) - hour;
                    minute = 59 - minute;
                    second = 60 - second;
                    if (second == 60)
                    {
                        minute = minute + 1;
                        second = 0;
                    }
                    if (minute == 60)
                    {
                        hour = hour + 1;
                        minute = 0;
                    }
                    minus = "-";
                }



            }
            if (day > 7)
            {
                if (hour >= wrkld)
                {
                    hour = hour - wrkld;
                    return hour + ":" + minute + ":" + second;

                }
                else
                {
                    hour = (wrkld - 1) - hour;
                    minute = 59 - minute;
                    second = 60 - second;
                    if (second == 60)
                    {
                        minute = minute + 1;
                        second = 0;
                    }
                    if (minute == 60)
                    {
                        hour = hour + 1;
                        minute = 0;
                    }

                    minus = "-";

                }



            }
            return minus + hour.ToString() + ":" + minute.ToString() + ":" + second.ToString();
        }
        public void createNewTableRow(String date, String difference, String workinghour, int days)
        {
            TableRow newrows = new TableRow();
            newrows.BackColor = System.Drawing.Color.Honeydew;
            TableCell Date = new TableCell();
            TableCell Day = new TableCell();
            TableCell Entry = new TableCell();
            TableCell Exit = new TableCell();
            TableCell Total = new TableCell();
            TableCell Timediff = new TableCell();
            Date.Text = "Notice";
            Day.Text = "  ";
            Entry.Text = " ";
            Exit.Text = " ";
            Total.Text = workinghour;
            Timediff.Text = "(" + (days * 8).ToString() + ") " + difference;
            newrows.Cells.Add(Date);
            newrows.Cells.Add(Day);
            newrows.Cells.Add(Entry);
            newrows.Cells.Add(Exit);
            newrows.Cells.Add(Total);
            newrows.Cells.Add(Timediff);
            Table1.Rows.Add(newrows);
        }
        public string CalculateTotalWorkingHours(int hour, int minute, int seconds)
        {
            totalHour += hour;
            totalMinute += minute;
            totalSeconds += seconds;
            while (totalSeconds >= 60)
            {
                totalSeconds = totalSeconds - 60;
                totalMinute += 1;
            }
            while (totalMinute >= 60)
            {
                totalMinute = totalMinute - 60;
                totalHour += 1;
            }

            return totalHour + ":" + totalMinute + ":" + totalSeconds;
        }
        public string calculateTotalDifference(int hour, int minute, int seconds)
        {

            totalHour += hour;
            totalMinute += minute;
            totalSeconds += seconds;
            while (totalSeconds >= 60)
            {
                totalSeconds = totalSeconds - 60;
                totalMinute += 1;
            }
            while (totalMinute >= 60)
            {
                totalMinute = totalMinute - 60;
                totalHour += 1;
            }

            return totalHour + ":" + totalMinute + ":" + totalSeconds;

        }
        public void update_database_Click()
        {
            database_updater updater = new database_updater();
        }
        //public void showholidays()
        //{
        //    String secondsnstrn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\database\\mydb.mdf;Integrated Security=True;Connect Timeout=30";

        //    SqlConnection myConnection = new SqlConnection(secondsnstrn);// Binds the Data on the page
        //    SqlCommand myCommand = new SqlCommand("select date from [dbo].[holiday]",
        //        myConnection);
        //    myCommand.CommandType = CommandType.Text;
        //    // Opens a Database Connection
        //    myConnection.Open();
        //    // Execute DataReader
        //    SqlDataReader dr = myCommand.ExecuteReader();
        //    // Read DataReader till it reaches the end
        //    while (dr.Read() == true)
        //    {
        //        // Assign the Calendar control dates
        //        // already contained in the database
        //      //  Calendar1.SelectedDates.Add(dr.GetDateTime(0));
        //     ///   Response.Write(dr.GetDateTime(0).ToShortDateString());
        //    }

        //    // Close DataReader
        //    dr.Close();
        //    // Close database Connection
        //    myConnection.Close();
        //}
        protected void Calendar1_DayRendered(EventArgs e, object sender)
        {
            Response.Write("Day Rendered");
        }
        protected void SHOWHOLIDAYS()
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

                //  Assign the Calendar control dates
                //   already contained in the database
                //       Calendar1.SelectedDates.Add(dr.GetDateTime(0));
                //    Response.Write("SHOWHOLIDAYS");
                //   Response.Write(dr.GetDateTime(0).ToShortDateString());
                //   Response.Write("</>");
            }
        }
        protected void year_SelectedIndexChanged(object sender, EventArgs e)
        {

            Button1.Visible = true;
        }
        protected void month_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!year.Visible || !month.Visible)
            {
                year.Visible = true;
                month.Visible = true;
                Button1.Visible = false;
            }
            else {
                year.Visible = false;
                month.Visible = false;

            }
           
           
        }
        //      public void getholidaydates(DateTime book) {
        //            String secondsnstrn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\database\\mydb.mdf;Integrated Security=True;Connect Timeout=30";

        //            SqlConnection mySqlConnection = new SqlConnection(secondsnstrn);// Binds the Data on the page


        //  SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
        // mySqlCommand.CommandText ="select date from holiday where date = @date";
        // mySqlCommand.Parameters.Add("@date", SqlDbType.DateTime);
        //            mySqlCommand.Parameters["@date"].Value = book;
        //                ;
        // mySqlConnection.Open();

        // SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader(CommandBehavior.SingleRow);


        //while (mySqlDataReader.Read()){

        //                Response.Write( mySqlDataReader["date"].ToString());


        //            }

        //         mySqlDataReader.Close();
        //          mySqlConnection.Close();

        //        }
        public void SetHolidaysData() {
            String secondsnstrn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\database\\mydb.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(secondsnstrn);// Binds the Data on the page
            string SqlString = "SELECT date FROM holiday;";

            SqlDataAdapter sda = new SqlDataAdapter(SqlString, con);
            try
            {
                con.Open();
                sda.Fill(holidays);
            }
            catch (SqlException)
            {

            }
            finally
            {
                con.Close();
            }

        }
        public Boolean thisdayholiday(DateTime selection) {


            foreach (DataRow row in holidays.Rows)
            {

                if (selection == Convert.ToDateTime(row[0].ToString()))
                {

                    return true;
                }
                else {
                    continue;

                }


            }
            return false;


        }
       
 protected void buttonclick(object sender, EventArgs e)
        {
            int nyear = Convert.ToInt32(year.SelectedValue);
          int  nmonth = Convert.ToInt32(month.SelectedValue);
            Calendar1.VisibleDate=new DateTime(nyear, nmonth,1);
            
            //
            DateTime firstOfMonth = new DateTime(nyear, nmonth, 1);
            DateTime lastDayOfMonth = new DateTime(nyear, nmonth+1, 1);

            List<DateTime> daysOfMonth = new List<DateTime>();
            for (DateTime dayCounter = firstOfMonth; dayCounter < lastDayOfMonth; dayCounter = dayCounter.AddDays(1))
            {
                Calendar1.SelectedDates.Add(dayCounter);
            }
  
         

            SetHolidaysData();
            Table1.Visible = true;
            Table2.Visible = false;
            DateTime today = DateTime.Now.Date;
            int daysnumber = 0;
            foreach (DateTime selecteddate in Calendar1.SelectedDates)
            {
                //   getholidaydates(selecteddate);
                //  Response.Write(selecteddate.ToString());
                daysnumber += 1;
                String b = selecteddate.DayOfWeek.ToString();
                date = selecteddate.Date;
                mymethod("54", "0", date, b, today);
            }
            if (daysnumber == 1)
            {
                numberOfDays = 1;
            }
            if (daysnumber == 7)
            {
                numberOfDays = 5 - holidaysinworkingdays;
            }
            if (daysnumber > 7)
            {
                numberOfDays = 20 - holidaysinworkingdays;
            }

            createNewTableRow("Conslusion", calculateDifference(totalHour, totalMinute, totalSeconds, numberOfDays), calculateTotalDifference(0, 0, 0), numberOfDays);
            workload = calculateDifference(totalHour, totalMinute, totalSeconds, numberOfDays);
            totalHour = 0;
            totalMinute = 0;
            totalSeconds = 0;
            Calendar1.SelectedDates.Clear();


        }
    }
    

}