using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// File: Library.aspx.cs
// Author: Vinson Sack
// Date: 09/27/2021
// Purpose: Not really much purpose here | Grid's are databound on the front end | Will be changed for next lab 

namespace Lab3
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {//smart page, wont allow on unless logged in 
            if (Session["UserName"] != null)
            {

            }
            else
            { //if not logged in 
                Session["InvalidUse"] = "You must login first to use the application!";
                Response.Redirect("Login.aspx");
            }

        }
    }
}