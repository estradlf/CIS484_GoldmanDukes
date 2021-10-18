using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
//DO NOT CHANGE CLASSIFIED TOP SECRET!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
namespace Lab3
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BoundField bfieldID = new BoundField();
                bfieldID.HeaderText = "ID";
                bfieldID.DataField = "ID";
                bfieldID.Visible = false;
                AnalyzedStories.Columns.Add(bfieldID);

                BoundField bfield = new BoundField();
                bfield.HeaderText = "Title";
                bfield.DataField = "Title";
                AnalyzedStories.Columns.Add(bfield);

                BoundField bfield2 = new BoundField();
                bfield2.HeaderText = "Results";
                bfield2.DataField = "Results";
                AnalyzedStories.Columns.Add(bfield2);

                BoundField bfield3 = new BoundField();
                bfield3.HeaderText = "Date";
                bfield3.DataField = "Date";
                AnalyzedStories.Columns.Add(bfield3);

                BoundField bfield4 = new BoundField();
                bfield4.HeaderText = "Status";
                bfield4.DataField = "Status";
                AnalyzedStories.Columns.Add(bfield4);

            }
            this.BindGrid();

        }
        private void BindGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("ID", typeof(int)), new DataColumn("Title", typeof(string)), new DataColumn("Results", typeof(string)), new DataColumn("Date", typeof(string)), new DataColumn("Status", typeof(string)) });

            //trying to get date shared in this jaunt          
            SqlConnection sqlUserList1 = new SqlConnection
                (WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            sqlUserList1.Open();

            string query2 = "SELECT a.analysisID, s.title, a.analysisResults, a.analysisDate, a.analysisStatus " +
                            "FROM AnalysisTask a, StoryText s, Users u " +
                            "WHERE u.userID = s.userID " +
                            "AND a.textID = s.textID " +
                            "AND u.userID = @userID " +
                            "ORDER BY a.analysisDate DESC";

            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = sqlUserList1;
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = query2;
            cmd3.Parameters.AddWithValue("@userID", Session["CurrentUser"]);
            SqlDataReader reader3 = cmd3.ExecuteReader();


            while (reader3.Read())
            {
                dt.Rows.Add(reader3.GetValue(0).ToString(), reader3.GetValue(1).ToString(), reader3.GetValue(2).ToString(), reader3.GetValue(3).ToString(), reader3.GetValue(4).ToString());
            }

            //dt.Rows.Add("John Hammond");
            AnalyzedStories.DataSource = dt;
            AnalyzedStories.DataBind();
        }
        protected void AnalyzedStories_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void AnalyzedStories_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("feed.aspx?textID=" + AnalyzedStories.SelectedValue);
        }

        // The id parameter name should match the DataKeyNames value set on the control
       /* public void AnalyzedStories_DeleteItem(int ID)
        {
            SqlConnection sqlDeleteUser = new SqlConnection
               (WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            string query = "DELETE FROM AnalysisTask WHERE analysisID = @analysisID AND userID = @userID";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlDeleteUser;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@analysisID", AnalyzedStories.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@userID", Session["CurrentUser"].ToString());

            cmd.ExecuteNonQuery();


        }*/
    }  
}