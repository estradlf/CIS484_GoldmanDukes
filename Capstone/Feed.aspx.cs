using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

// File: Feed.aspx.cs
// Author: Vinson Sack
// Date: 10/7/2021
// Purpose: Logic behind the Feed webform to See shared results.  Provides functionality to the page

namespace Lab3
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {//smart page 
            if (Session["UserName"] != null)
            {
                if (!IsPostBack)
                {//load shared stories into drop down | user selects | data for that post appears 
                    try
                    {
                        SqlConnection sqlConnection =
                            new SqlConnection(
                                    WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

                        string query = "Select title, textID from StoryText WHERE textID IN (Select textID from AnalysisTask Where analysisID IN (Select taskID From ShareResults Where userID = @userID))";
                        SqlCommand sqlUpdateUser = new SqlCommand();
                        sqlUpdateUser.Connection = sqlConnection;

                        sqlUpdateUser.CommandType = CommandType.Text;
                        sqlUpdateUser.CommandText = query;
                        sqlUpdateUser.Parameters.AddWithValue("@userID", Session["CurrentUser"]);


                        sqlConnection.Open();

                        SqlDataReader reader = sqlUpdateUser.ExecuteReader();

                        while (reader.Read())
                        {
                            ddlStory.Items.Add(new ListItem(reader.GetValue(0).ToString(), reader.GetValue(1).ToString()));
                        }
                        sqlConnection.Close();
                    }
                    catch (Exception)
                    {
                        lblError.Text = "Error";
                    }
                }
            }
            else
            {
                Session["InvalidUse"] = "You must login first to use the application!";
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {// queries that will populate the text fields with the corresponding data 
            try
            {
                SqlConnection sqlConnection =
                    new SqlConnection(
                            WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());

                string owner = "SELECT firstName + ' ' + lastName FROM Users WHERE userID = (SELECT Lab3.dbo.StoryText.userID FROM Lab3.dbo.StoryText WHERE Lab3.dbo.StoryText.textID = @textID)";
                SqlCommand ownerName = new SqlCommand();
                ownerName.Connection = sqlConnection;
                ownerName.CommandType = CommandType.Text;
                ownerName.CommandText = owner;
                ownerName.Parameters.AddWithValue("@textID", ddlStory.SelectedValue.ToString());

                sqlConnection.Open();

                SqlDataReader ownTxtBox = ownerName.ExecuteReader();

                while (ownTxtBox.Read())
                {
                    txtSharedBy.Text = ownTxtBox.GetValue(0).ToString();
                }
            }
            catch (SqlException)
            {
                lblError.Text = "error";
            }
            try
            {
                SqlConnection sqlConnection1 =
                    new SqlConnection(
                            WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString.ToString());

                string restBoxes = "SELECT s.title, s.source, sr.dateShared, a.analysisResults FROM StoryText s, ShareResults sr, AnalysisTask a WHERE s.textID = a.textID AND a.analysisID = sr.taskID AND s.textID = @textID";
                SqlCommand sharePost = new SqlCommand();
                sharePost.Connection = sqlConnection1;
                sharePost.CommandType = CommandType.Text;
                sharePost.CommandText = restBoxes;
                sharePost.Parameters.AddWithValue("@textID", ddlStory.SelectedValue.ToString());

                sqlConnection1.Open();

                SqlDataReader ownTxtBox1 = sharePost.ExecuteReader();

                while (ownTxtBox1.Read())
                {
                    txtTitle.Text = ownTxtBox1.GetValue(0).ToString();                    
                    txtSource.Text = ownTxtBox1.GetValue(1).ToString();
                    txtDateShared.Text = ownTxtBox1.GetValue(2).ToString();
                    txtResults.Text = ownTxtBox1.GetValue(3).ToString();

                }
            }
            catch (SqlException)
            {
                lblError.Text = "Error";
            }
        }
    }
}