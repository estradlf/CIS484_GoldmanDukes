using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;


// File: NewUser.aspx.cs
// Author: Vinson Sack
// Date: 10/07/2021
// Purpose: Back-end to allow users to log in | also works with PasswordHash.cs


namespace Lab3
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {//Not Smart Page For users to sign up, once signed up they can access the application 

            //No Functionality will be seen from this page in terms of links | even if they would they are all smart
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {           
            try
            {
                //query to add new user 
                SqlConnection authConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());
                SqlCommand sqlCreateUser = new SqlCommand();

                sqlCreateUser.Connection = authConnection;
                sqlCreateUser.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCreateUser.CommandText = "sp_newUserProtocol"; // My protocol

                sqlCreateUser.Parameters.AddWithValue("@firstName", HttpUtility.HtmlEncode(txtFirstName.Text));
                sqlCreateUser.Parameters.AddWithValue("@lastName", HttpUtility.HtmlEncode(txtLastName.Text));
                sqlCreateUser.Parameters.AddWithValue("@username", HttpUtility.HtmlEncode(txtUserName.Text));
                sqlCreateUser.Parameters.AddWithValue("@emailAddress", HttpUtility.HtmlEncode(txtEmail.Text));
                sqlCreateUser.Parameters.AddWithValue("@phoneNumber", HttpUtility.HtmlEncode(txtPhone.Text));
                sqlCreateUser.Parameters.AddWithValue("@street", HttpUtility.HtmlEncode(txtStreet.Text));
                sqlCreateUser.Parameters.AddWithValue("@city", HttpUtility.HtmlEncode(txtCity.Text));
                sqlCreateUser.Parameters.AddWithValue("@state", HttpUtility.HtmlEncode(txtState.Text));
                sqlCreateUser.Parameters.AddWithValue("@zip", HttpUtility.HtmlEncode(txtZip.Text));
                sqlCreateUser.Parameters.AddWithValue("@hashedPassword", PasswordHash.HashPassword(HttpUtility.HtmlEncode(txtPassword.Text)));
                sqlCreateUser.Parameters.AddWithValue("@reason", ddlReason.SelectedValue.ToString());

                authConnection.Open();

                SqlDataReader results = sqlCreateUser.ExecuteReader();

                authConnection.Close();
                results.Close();

                //assigning session variable and then moving to homepage 
                Session["UserName"] = txtUserName.Text;
                Response.Redirect("HomePage1.aspx");
            }
            catch (SqlException)
            {
                lblStatus.Text = "Error!";
            }

        }
        // populate and clear logic 
        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "JohnSmith";
            txtPassword.Text = "password";
            txtFirstName.Text = "John";
            txtLastName.Text = "Smith";
            txtEmail.Text = "JohnSmith@email.com";
            txtPhone.Text = "703-123-3212";
            txtState.Text = "VA";
            txtStreet.Text = "Devon Lane";
            txtCity.Text = "Harrisonburg";
            txtZip.Text = "22801";

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtCity.Text = "";
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPassword.Text = "";
            txtPhone.Text = "";
            txtState.Text = "";
            txtStreet.Text = "";
            txtUserName.Text = "";
            txtZip.Text = "";
        }
    }
}