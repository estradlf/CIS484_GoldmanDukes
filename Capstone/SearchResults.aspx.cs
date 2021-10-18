using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

// File: SearchResults.aspx.cs
// Author: Vinson Sack
// Date: 10/07/2021
// Purpose: Search Results Population

namespace Lab3
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {//smartPage
            if (Session["UserName"] != null)
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString.Get("Input") != "")
                    {//making sure input is not null
                        loadUserData(); // load the Friends data 
                       try
                        {//query to determine if the two users are friends or not 
                            SqlConnection sqlConnect = new SqlConnection
                                (WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                            sqlConnect.Open();

                            string sqlQuery = "SELECT COUNT(friendID) FROM dbo.AssociatedUser WHERE userID = @userID AND friendID = @friendID";

                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = sqlConnect;
                            cmd.CommandType = System.Data.CommandType.Text;
                            cmd.CommandText = sqlQuery;
                            cmd.Parameters.AddWithValue("@userID", Session["CurrentUser"]);
                            cmd.Parameters.AddWithValue("@friendID", txtUserID.Text);

                    
                            int count = Convert.ToInt32(cmd.ExecuteScalar());
                            sqlConnect.Close();

                            //results determine if the user can add or delete friend 
                            if (count == 1)
                            {
                                btnRemoveFriend.Visible = true;
                                btnAddFriend.Visible = false;
                                lblStatus.Text = "Already Friends!";
                            }
                            else
                            {
                                btnAddFriend.Visible = true;
                                btnRemoveFriend.Visible = false; 
                            }     
                       }
                       catch (SqlException)
                       {
                            lblStatus.Text = "There was an error";
                       }
                    }
                    else
                    {                       
                        Response.Redirect("HomePage1.aspx");
                    }
                }
            }
            else
            { //if not logged in 
                Session["InvalidUse"] = "You must login first to use the application!";
                Response.Redirect("Login.aspx");
            }

        }

        protected void btnAddFriend_Click(object sender, EventArgs e)
        { // adding a friend
            try
            {
                //simple query that will insert into associated user 
                SqlConnection sqlConnect = new SqlConnection
                    (WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                sqlConnect.Open();

                string sqlQuery = "INSERT INTO AssociatedUser (userID, friendID) VALUES (@userID, @friendID)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnect;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sqlQuery;
                cmd.Parameters.AddWithValue("@userID", Session["CurrentUser"]);
                cmd.Parameters.AddWithValue("@friendID", HttpUtility.HtmlEncode(txtUserID.Text));

                SqlDataReader reader = cmd.ExecuteReader();

                sqlConnect.Close();
                reader.Close();

                btnAddFriend.Text = "Friend Added Successfully!";
            }
            catch (SqlException)
            {
                lblStatus.Text = "There was an error adding this user as a friend"; 
            }

        }
        protected void loadUserData()
        { // loading users data 
            try
            {
                //Loading user data 
                SqlConnection sqlConnect = new SqlConnection
                        (WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);

                sqlConnect.Open();
                string query = "Select firstName, lastName, emailAddress, biography, userID from dbo.Users WHERE emailAddress = @input";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnect;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@input", HttpUtility.HtmlEncode(Request.QueryString.Get("Input").ToString()));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {//reading the query results and then putting the values into the 
                    txtFirstName.Text = reader.GetValue(0).ToString();
                    txtLastName.Text = reader.GetValue(1).ToString();
                    txtEmail.Text = reader.GetValue(2).ToString();
                    txtBio.Text = reader.GetValue(3).ToString();
                    txtUserID.Text = reader.GetValue(4).ToString();
                }

                //close all related connections 
                reader.Close();
                sqlConnect.Close();

            }
            catch (SqlException)
            {
                lblStatus.Text = "There was an error";
            }
        }

        protected void btnRemoveFriend_Click(object sender, EventArgs e)
        { // removing friends 
            try
            {
                SqlConnection sqlConnect = new SqlConnection
                    (WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                sqlConnect.Open();

                string sqlQuery = "DELETE FROM AssociatedUser WHERE userID = @userID AND friendID =@friendID";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnect;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sqlQuery;
                cmd.Parameters.AddWithValue("@userID", Session["CurrentUser"]);
                cmd.Parameters.AddWithValue("@friendID", HttpUtility.HtmlEncode(txtUserID.Text));

                SqlDataReader reader = cmd.ExecuteReader();

                sqlConnect.Close();
                reader.Close();
            }
            catch (Exception)
            {

                lblStatus.Text = "Error";
            }
        }
    }
}