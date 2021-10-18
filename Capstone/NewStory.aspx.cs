using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.IO;

// File: NewStory.aspx.cs
// Author: Vinson Sack
// Date: 10/07/2021
// Purpose: Logic to the New Story front end | Allows user to insert new stories into the db 

namespace Lab3
{
    public partial class WebForm5 : System.Web.UI.Page
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!txtBody.Text.Equals("")) //only used if body is not null
            {
                //cleaning data 
                string x = txtBody.Text;
                string z = x.Replace("'", "");
                try
                {//inserting into db
                    String sqlQuery = "INSERT INTO StoryText (title, source, body, dateAdded, description, userID) VALUES" +
                      "(@title, @source, @body, @dateAdded, @description, @userID)";


                    SqlConnection sqlConnect = new SqlConnection
                         (WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                    SqlCommand sqlNewStory = new SqlCommand();
                    sqlNewStory.Connection = sqlConnect;
                    sqlNewStory.CommandType = CommandType.Text;
                    sqlNewStory.CommandText = sqlQuery;
                    sqlNewStory.Parameters.AddWithValue("@title", HttpUtility.HtmlEncode(txtTitle.Text));
                    sqlNewStory.Parameters.AddWithValue("@source", HttpUtility.HtmlEncode(txtSource.Text));
                    sqlNewStory.Parameters.AddWithValue("@body", HttpUtility.HtmlEncode(txtBody.Text));
                    sqlNewStory.Parameters.AddWithValue("@dateAdded", HttpUtility.HtmlEncode(txtDate.Text));
                    sqlNewStory.Parameters.AddWithValue("@description", HttpUtility.HtmlEncode(txtDescription.Text));
                    sqlNewStory.Parameters.AddWithValue("@userID", Session["CurrentUser"]);

                    sqlConnect.Open();
                    SqlDataReader queryResults = sqlNewStory.ExecuteReader();

                    queryResults.Close();
                    sqlConnect.Close();
                }
                catch (SqlException)
                {
                    lblError.Text = "There was error adding this text to the database.  Please Try Again!";
                }
            }
            else
            {//else used for the file section 
                if (fileUpload.HasFile)
                {
                    String fpath = Request.PhysicalApplicationPath + "textfiles\\" +
                        fileUpload.FileName;
                    fileUpload.SaveAs(fpath);

                    if (File.Exists(fpath))
                    {
                        string strFile = File.ReadAllText(fpath);
                        File.Delete(fpath);

                        try
                        {        // inserting into db                                             
                            String sqlQuery = "INSERT INTO StoryText (title, source, body, dateAdded, description, userID) VALUES" +
                              "(@title, @source, @body, @dateAdded, @description, @userID)";

                            SqlConnection sqlConnect = new SqlConnection
                                 (WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                            SqlCommand sqlNewStory = new SqlCommand();
                            sqlNewStory.Connection = sqlConnect;
                            sqlNewStory.CommandType = CommandType.Text;
                            sqlNewStory.CommandText = sqlQuery;
                            sqlNewStory.Parameters.AddWithValue("@title", HttpUtility.HtmlEncode(txtTitle.Text));
                            sqlNewStory.Parameters.AddWithValue("@source", HttpUtility.HtmlEncode(txtSource.Text));
                            sqlNewStory.Parameters.AddWithValue("@body", strFile.Replace("'", "").ToString());
                            sqlNewStory.Parameters.AddWithValue("@dateAdded", HttpUtility.HtmlEncode(txtDate.Text));
                            sqlNewStory.Parameters.AddWithValue("@description", HttpUtility.HtmlEncode(txtDescription.Text));
                            sqlNewStory.Parameters.AddWithValue("@userID", Session["CurrentUser"]);

                            sqlConnect.Open();
                            SqlDataReader queryResults = sqlNewStory.ExecuteReader();

                            queryResults.Close();
                            sqlConnect.Close();
                        }
                        catch (SqlException)
                        {
                            lblError.Text = "There was error adding this text to the database.  Please Try Again!";
                        }
                    }
                }
            }
        }
        //populate and clear 
        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            txtBody.Text = "Joe Rogan gets inducted into the UFC Hall of Fame for amazing broadcasting. He has played a huge role within our industry and we are so happy to have him. - Dana White CEO";
            txtTitle.Text = "UFC: Joe Rogan = Hall of Fame";
            txtSource.Text = "ESPN";
            txtDate.Text = "2021-09-12";
            txtDescription.Text = "Sports";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtBody.Text = "";
            txtDate.Text = "";
            txtDescription.Text = "";
            txtSource.Text = "";
            txtTitle.Text = "";
        }
    }
}