using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

// File: Bio.aspx.cs
// Author: Vinson Sack
// Date:10/7/2021
// Purpose: Logic behind for the bio page. Provides functionality to buttons as well as updates the db 

namespace Lab3
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { //smart page, wont allow on unless logged in 
            if (Session["UserName"] != null)
            {
               if (!IsPostBack)
                {
                    loadUserData(); //used to load the users data who is logged on 
               }
                
            }
            else
            { //if not logged in 
                Session["InvalidUse"] = "You must login first to use the application!";
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            txtBio.Text = "Historian at History.com";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        { //Update logic CSS protected 
            try
            {
                SqlConnection sqlConnection =
                    new SqlConnection(
                        WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());

                SqlCommand sqlUpdateUser = new SqlCommand();
                sqlUpdateUser.Connection = sqlConnection;

                sqlUpdateUser.CommandType = CommandType.StoredProcedure;
                sqlUpdateUser.CommandText = "sp_UpdateUserProcedure";
                sqlUpdateUser.Parameters.AddWithValue("@firstName", HttpUtility.HtmlEncode(txtFirstName.Text.ToString()));
                sqlUpdateUser.Parameters.AddWithValue("@lastName", HttpUtility.HtmlEncode(txtLastName.Text.ToString()));
                sqlUpdateUser.Parameters.AddWithValue("@emailAddress", HttpUtility.HtmlEncode(txtEmail.Text.ToString()));
                sqlUpdateUser.Parameters.AddWithValue("@phoneNumber", HttpUtility.HtmlEncode(txtPhone.Text.ToString()));
                sqlUpdateUser.Parameters.AddWithValue("@street", HttpUtility.HtmlEncode(txtStreet.Text.ToString()));
                sqlUpdateUser.Parameters.AddWithValue("@city", HttpUtility.HtmlEncode(txtCity.Text.ToString()));
                sqlUpdateUser.Parameters.AddWithValue("@state", HttpUtility.HtmlEncode(txtState.Text.ToString()));
                sqlUpdateUser.Parameters.AddWithValue("@zip", HttpUtility.HtmlEncode(txtZip.Text.ToString()));
                sqlUpdateUser.Parameters.AddWithValue("@biography", HttpUtility.HtmlEncode(txtBio.Text.ToString()));
                sqlUpdateUser.Parameters.AddWithValue("@userID", Session["CurrentUser"].ToString());

                sqlConnection.Open();

                SqlDataReader Update = sqlUpdateUser.ExecuteReader();

                sqlConnection.Close();
                loadUserData();
            }
            catch (Exception)
            {
                lblStatus.Text = "Error";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtBio.Text = "";
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx?loggedOut=true");
        }
        protected void loadUserData()
        {//method to load users data 
            try
            {
                //Loading user data 
                SqlConnection sqlConnect = new SqlConnection
                        (WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);

                sqlConnect.Open();

                SqlCommand cmd = new SqlCommand("Select firstName, lastName, emailAddress, phoneNumber, street, city, state, zip, biography from dbo.Users WHERE userID = '" + Session["CurrentUser"] + "'", sqlConnect);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {//reading the query results and then putting the values into the 
                    txtFirstName.Text = reader.GetValue(0).ToString();
                    txtLastName.Text = reader.GetValue(1).ToString();
                    txtEmail.Text = reader.GetValue(2).ToString();
                    txtPhone.Text = reader.GetValue(3).ToString();
                    txtStreet.Text = reader.GetValue(4).ToString();
                    txtCity.Text = reader.GetValue(5).ToString();
                    txtState.Text = reader.GetValue(6).ToString();
                    txtZip.Text = reader.GetValue(7).ToString();
                    txtBio.Text = reader.GetValue(8).ToString();
                }

                //close all related connections 
                reader.Close();
                sqlConnect.Close();
               
            }
            catch (SqlException)
            {
                lblStatus.Text = "There was an error loading user data";
            }

           try
           { // query for friends names
                 SqlConnection sqlUserList = new SqlConnection
                        (WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString);

                 sqlUserList.Open();

                 string query = "SELECT AUTH.dbo.Users.firstName + ' ' + AUTH.dbo.Users.lastName, AUTH.dbo.Users.userID FROM AUTH.dbo.Users WHERE userID IN (SELECT Lab3.dbo.AssociatedUser.friendID FROM Lab3.dbo.AssociatedUser WHERE Lab3.dbo.AssociatedUser.userID = @userID)";
                 SqlCommand cmd2 = new SqlCommand();
                 cmd2.Connection = sqlUserList;
                 cmd2.CommandType = CommandType.Text;
                 cmd2.CommandText = query;
                 cmd2.Parameters.AddWithValue("@userID", Session["CurrentUser"]);
                 SqlDataReader reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    ddlCurrentFriends.Items.Add(new ListItem(reader2.GetValue(0).ToString(), reader2.GetValue(1).ToString()));
                }
            }
           catch (SqlException)
            {

               lblStatus.Text = "There was an error drop down list";
            }

            try
            { // query to count frineds 
                SqlConnection sqlUserCount = new SqlConnection
                        (WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

                sqlUserCount.Open();

                SqlCommand cmd1 = new SqlCommand("Select COUNT(userID) from dbo.AssociatedUser WHERE userID = '" + Session["CurrentUser"] + "'", sqlUserCount);
                SqlDataReader reader1 = cmd1.ExecuteReader();

                while (reader1.Read())
                {
                    txtFriendCount.Text = reader1.GetValue(0).ToString();
                }
            }
            catch (SqlException)
            {

                lblStatus.Text = "There was an error with friend count";
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
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
                cmd.Parameters.AddWithValue("@friendID", ddlCurrentFriends.SelectedValue.ToString());

                SqlDataReader reader = cmd.ExecuteReader();

                sqlConnect.Close();
                reader.Close();
                ddlCurrentFriends.Items.Clear(); 
                loadUserData();
            }
            catch (Exception)
            {

                lblStatus.Text = "Error";
            }
        }
    }
}