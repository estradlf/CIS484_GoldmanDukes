using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Drawing;
// File: Login.aspx.cs
// Author: Vinson Sack
// Date: 10/07/2021
// Purpose: Login Page logic encorporated with Encryption page allowing a user a safe way to log on to the platform 


namespace Lab3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //logic to determine if user logged out or didn't sign in           
            if (Request.QueryString.Get("LoggedOut") == "true")
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Font.Bold = false;
                lblStatus.Text = "User has successfully logged out";
            }
            if (Session["InvalidUse"] != null)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Font.Bold = true;
                lblStatus.Text = Session["InvalidUse"].ToString();
            }
        }

        //Login Logic 
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                 SqlConnection sqlConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["AUTH"].ConnectionString.ToString());
                 SqlCommand sqlValUser = new SqlCommand();

                 sqlValUser.Connection = sqlConnection;
                 sqlValUser.CommandType = System.Data.CommandType.StoredProcedure;
                 sqlValUser.CommandText = "JeremyEzellLab3"; //your procedure 
                 sqlValUser.Parameters.AddWithValue("@username", HttpUtility.HtmlEncode(txtUsername.Text));
                 sqlConnection.Open();
                 SqlDataReader reader = sqlValUser.ExecuteReader();
            

                //validating password
                 if (reader.HasRows)
                 {
                     while (reader.Read())
                     {
                         string storedHash = reader["hashedPassword"].ToString();
                         if(PasswordHash.ValidatePassword(txtPassword.Text, storedHash))
                         {
                             Session["UserName"] = HttpUtility.HtmlEncode(txtUsername.Text);
                             Response.Redirect("HomePage1.aspx");
                         }
                         else
                         {
                             lblStatus.ForeColor = Color.Red;
                             lblStatus.Font.Bold = true;
                             lblStatus.Text = "Either the username and/or password is incorrect";
                         }
                     }
                 }
            }
            catch (SqlException)
            {
                lblStatus.Text = "There was an error!";
            }
        }

        //sign up 
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewUser.aspx");
        }
    }
}