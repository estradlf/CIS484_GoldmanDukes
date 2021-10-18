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
                        // page load with values from selected index from gridview | lets go 

                        //start with the name 
                        SqlConnection sqlConnection =
                             new SqlConnection(
                                        WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());

                        string owner = "SELECT firstName + ' ' + lastName FROM Users WHERE userID = (SELECT Lab3.dbo.StoryText.userID FROM Lab3.dbo.StoryText WHERE Lab3.dbo.StoryText.textID = @textID)";
                        SqlCommand ownerName = new SqlCommand();
                        ownerName.Connection = sqlConnection;
                        ownerName.CommandType = CommandType.Text;
                        ownerName.CommandText = owner;
                        ownerName.Parameters.AddWithValue("@textID", Request.QueryString.Get("textID").ToString());

                        sqlConnection.Open();

                        SqlDataReader ownTxtBox = ownerName.ExecuteReader();

                        while (ownTxtBox.Read())
                        {
                            txtSharedBy.Text = ownTxtBox.GetValue(0).ToString();
                        }

                       



                    }
                    catch (Exception)
                    {
                        lblError.Text = "Error";
                    }

                    //fills out everything else
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
                        sharePost.Parameters.AddWithValue("@textID", Request.QueryString.Get("textID").ToString());

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
            else
            {
                Session["InvalidUse"] = "You must login first to use the application!";
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("GridViewFeed.aspx");
        }
    }
}