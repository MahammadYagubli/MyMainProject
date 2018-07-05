using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


namespace test
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FormsAuthentication.Authenticate(TextBox1.Text, TextBox2.Text)) {
               Application["user_name"] = TextBox1.Text;
                Application["password"] = TextBox2.Text;
                FormsAuthentication.RedirectFromLoginPage(TextBox1.Text, true);
                Server.Transfer("~/stuff.aspx");
            }
               else
            {
                Application["user_name"] = TextBox1.Text;
                Application["password"] = TextBox2.Text;
                 Response.Write("You did not authenticated ");
                       if(Session["numbee_of_trials"]==null){
                    Session["numbee_of_trials"] = 1;
 
                }
               
                if(Convert.ToInt32(Session["numbee_of_trials"])==3)
                {
                     Server.Transfer("~/error/myerror.aspx");
 
                }
                else                  
                       {

                    Session["numbee_of_trials"] = Convert.ToInt32(Session["numbee_of_trials"]) + 1;

                }

            }
         }
    }
}