using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.IO;

// File: AnalysisRequest.aspx.cs
// Author: Vinson Sack
// Date: 10/7/2021
// Purpose: Logic behind the AnalysisRequest webform to create a request for an analysis.  Provides functionality to the page


namespace Lab3
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {//smart web page will not allow a user in if they are not logged on
            if (Session["UserName"] != null)
            {
                if (!IsPostBack)
                {
                    //query to fill the drop down box with the logged on users stories 
                    try
                    {
                        String sqlQuery = "Select s.title, s.textID FROM dbo.Users u, dbo.StoryText s WHERE u.userID = @CurrentUser AND s.userID = @CurrentUser";

                        SqlConnection sqlConnect = new SqlConnection
                             (WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                        SqlCommand sqlAnalysisReq = new SqlCommand();
                        sqlAnalysisReq.Connection = sqlConnect;
                        sqlAnalysisReq.CommandType = System.Data.CommandType.Text;
                        sqlAnalysisReq.CommandText = sqlQuery;
                        sqlAnalysisReq.Parameters.AddWithValue("@CurrentUser", Session["CurrentUser"]);
                        sqlConnect.Open();
                        SqlDataReader reader = sqlAnalysisReq.ExecuteReader();
                        while (reader.Read())
                        {//reading the query results and then putting the values into the 
                            ddlStory.Items.Add(new ListItem(reader.GetValue(0).ToString(), reader.GetValue(1).ToString()));
                        }
                    }
                    catch (SqlException)
                    {
                        txtStatus.Text = "There was an error";
                    }

                    //Selecting Users Friends 
                    try
                    {
                        string query = "SELECT firstName + ' ' + lastName, userID FROM Users WHERE userID IN (SELECT Lab3.dbo.AssociatedUser.friendID FROM Lab3.dbo.AssociatedUser WHERE Lab3.dbo.AssociatedUser.userID = @userID)";

                        SqlConnection sqlConnect = new SqlConnection
                                (WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);

                        SqlCommand friends = new SqlCommand();
                        friends.Connection = sqlConnect;
                        friends.CommandType = System.Data.CommandType.Text;
                        friends.CommandText = query;
                        friends.Parameters.AddWithValue("@userID", Session["CurrentUser"]);

                        sqlConnect.Open();

                        SqlDataReader results = friends.ExecuteReader();

                        while (results.Read())
                        {
                            ddlFriends.Items.Add(new ListItem(results.GetValue(0).ToString(), results.GetValue(1).ToString()));
                        }
                    }
                    catch (SqlException)
                    {
                        lblError.Text = "Error";
                    }
                }

            }
            else //if not logged on redirected 
            {
                Session["InvalidUse"] = "You must login first to use the application!";
                Response.Redirect("Login.aspx");
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //allow user to see results here | as well as in the library 
            lblResults.Visible = true;
            txtResults.Visible = true;
            ddlFriends.Visible = true;
            btnShare.Visible = true;
            lblShare.Visible = true;
            //dummy data for results 
            txtResults.Text = "Doggo ipsum doing me a frighten heck fluffer yapper what a nice floof.";

            try
            { // query to insert into the db 
              //updating section 

                SqlConnection sqlConnect = new SqlConnection
                        (WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);
                                
                string sqlQuery = "INSERT INTO dbo.AnalysisTask(userID, textID, analysisDate, analysisReason, analysisResults, analysisStatus)" +
                    " VALUES ( @userID, @textID, @analysisDate, @analysisReason, @analysisResults, @analysisStatus)"; 
                SqlCommand analysisReq = new SqlCommand();
                analysisReq.Connection = sqlConnect;
                analysisReq.CommandType = System.Data.CommandType.Text;
                analysisReq.CommandText = sqlQuery;
                analysisReq.Parameters.AddWithValue("@userID", Session["CurrentUser"]);
                analysisReq.Parameters.AddWithValue("@textID", ddlStory.SelectedValue);
                analysisReq.Parameters.AddWithValue("@analysisDate", HttpUtility.HtmlEncode(txtDate.Text));
                analysisReq.Parameters.AddWithValue("@analysisReason", ddlReason.SelectedValue.ToString());
                analysisReq.Parameters.AddWithValue("@analysisResults", HttpUtility.HtmlEncode(txtResults.Text));
                analysisReq.Parameters.AddWithValue("@analysisStatus", "Completed");
                sqlConnect.Open();
                SqlDataReader queryResults = analysisReq.ExecuteReader();


                // Close all related connections
                queryResults.Close();
                sqlConnect.Close();

                //make visible here 
            }
           catch (SqlException)
            {
               lblStatus.Visible = true;
               txtStatus.Visible = true;
               txtStatus.Text = "There was an error updating";
            }
        }

        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            //populate logic 
            txtDate.Text = "2021-09-24";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {//clear
            txtDate.Text = "";
            txtResults.Text = "";
            txtStatus.Text = "";
        }

        protected void btnShare_Click(object sender, EventArgs e)
        {// two queries, first find the highest analysistask inorder to place into Share table properly | second inserts 
            try
            {
                string max = "SELECT MAX(AnalysisID) FROM AnalysisTask";
                string friend = "INSERT INTO ShareResults (userID, taskID, dateShared) VALUES (@userID, @taskID, @dateShared)";

                SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                sqlConnect.Open();
                SqlCommand findMax = new SqlCommand();
                findMax.Connection = sqlConnect;
                findMax.CommandType = System.Data.CommandType.Text;
                findMax.CommandText = max;

                int MaxAnalysis = Convert.ToInt32(findMax.ExecuteScalar());

                SqlCommand sharePost = new SqlCommand();
                sharePost.Connection = sqlConnect;
                sharePost.CommandType = System.Data.CommandType.Text;
                sharePost.CommandText = friend;
                sharePost.Parameters.AddWithValue("@userID", ddlFriends.SelectedValue.ToString());
                sharePost.Parameters.AddWithValue("@taskID", MaxAnalysis);
                sharePost.Parameters.AddWithValue("@dateShared", DateTime.Now);

                SqlDataReader reader = sharePost.ExecuteReader();

                sqlConnect.Close();
                lblStatus.Text = "Shared Successfully!";
            }
            catch (SqlException)
            {

                lblError.Text = "Error Sharing to User!";
            }
        }
    }
}