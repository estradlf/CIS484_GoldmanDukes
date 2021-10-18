using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

// File: MainTemplate.Master.cs
// Author: Vinson Sack
// Date: 09/27/2021
// Purpose: Master page used to provide consistent functionality for all "Sub" Pages 

namespace Lab3
{
    public partial class MainTemplate : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {//if logged in the user will see all of the tabs 
                btnLogOut.Visible = true;
                btnCurrentUser.Visible = true;
                btnSearch.Visible = true;
                txtSearch.Visible = true;
                lbtnAnalyzedLibrary.Visible = true;
                lbtnLibrary.Visible = true;
                lbtnNewStory.Visible = true;
                lbtnRequest.Visible = true;
                try//loads the users first name into the corner tab
                {
                //Loading user data 
                SqlConnection sqlConnect = new SqlConnection
                            (WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);

                    sqlConnect.Open();

                    //No User Interaction 
                    SqlCommand cmd = new SqlCommand("Select username,userID from dbo.Users WHERE username ='" + Session["UserName"].ToString() + "'", sqlConnect);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {//reading the query results and then putting the values into the 
                        btnCurrentUser.Text = reader.GetValue(0).ToString();
                        Session["CurrentUser"] = reader.GetValue(1).ToString();                        
                    }

                    //close all related connections 
                    reader.Close();
                    sqlConnect.Close();

                }
                catch (SqlException)
                {

                }

            }
            else
            {//not logged on means they cant see any tabs | Smart application 
                btnLogOut.Visible = false;
                btnCurrentUser.Visible = false;
                btnSearch.Visible = false;
                txtSearch.Visible = false;
                lbtnAnalyzedLibrary.Visible = false;
                lbtnLibrary.Visible = false;
                lbtnNewStory.Visible = false;
                lbtnRequest.Visible = false;

            }
        }

        //redirect to new story 
        protected void lbtnNewStory_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewStory.aspx");
        }

        //Analysis Request
        protected void lbtnRequest_Click(object sender, EventArgs e)
        {
            Response.Redirect("AnalysisRequest.aspx");
        }

        //Library Logic 
        protected void lbtnLibrary_Click(object sender, EventArgs e)
        {
            Response.Redirect("Library.aspx");
        }

        //UserProfile button = the users name
        protected void btnCurrentUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("Bio.aspx");
        }

        //Logout Logic
        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx?loggedOut=true");

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //redirects to Search Results and passes an Input variable
            Response.Redirect("SearchResults.aspx?Input=" + HttpUtility.HtmlEncode(txtSearch.Text));
        }

        protected void lbtnAnalyzedLibrary_Click(object sender, EventArgs e)
        {
            Response.Redirect("GetAnalysis.aspx");
        }

        protected void lbtnFeed_Click(object sender, EventArgs e)
        {
            Response.Redirect("Feed.aspx");
        }
    }
}