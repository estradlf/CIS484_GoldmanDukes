using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// File: HomePage1.aspx.cs
// Author: Vinson Sack
// Date: 10/7/2021
// Purpose: Provide a nice looking home page for the user as well as logic for front end 

namespace Lab3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {//smart page
            if (Session["UserName"] != null)
            {

            }
            else
            {
                Session["InvalidUse"] = "You must login first to use the application!";
                Response.Redirect("Login.aspx");
            }

        }

        //Redirects for links on homepage 
        protected void btnLibrary_Click(object sender, EventArgs e)
        {
            Response.Redirect("Library.aspx");
        }

        protected void btnStory_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewStory.aspx");
        }

        protected void btnRequest_Click(object sender, EventArgs e)
        {
            Response.Redirect("AnalysisRequest.aspx");
        }
    }
}