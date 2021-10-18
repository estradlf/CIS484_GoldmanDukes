using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BoundField bfieldID = new BoundField();
                bfieldID.HeaderText = "ID";
                bfieldID.DataField = "ID";
                bfieldID.Visible = false; 
                friends.Columns.Add(bfieldID);

                BoundField bfield = new BoundField();
                bfield.HeaderText = "Title";
                bfield.DataField = "Title";
                friends.Columns.Add(bfield);

                BoundField bfield2 = new BoundField();
                bfield2.HeaderText = "Results";
                bfield2.DataField = "Results";
                friends.Columns.Add(bfield2);

                BoundField bfield3 = new BoundField();
                bfield3.HeaderText = "Date Shared";
                bfield3.DataField = "Date Shared";
                friends.Columns.Add(bfield3);

            }
            this.BindGrid();

        }

        private void BindGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("ID", typeof(int)), new DataColumn("Title", typeof(string)), new DataColumn("Results", typeof(string)), new DataColumn("Date Shared", typeof(string))});
  
            //trying to get date shared in this jaunt          
            SqlConnection sqlUserList1 = new SqlConnection
                (WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            sqlUserList1.Open();

            string query2 = "select s.textID, s.title, a.analysisResults, sh.dateShared " + 
                            "from StoryText s, AnalysisTask a, ShareResults sh " + 
                            "WHERE s.textID = a.textID " + 
                            "AND a.analysisID = sh.taskID " + 
                            "AND sh.userID = @userID " +
                            "ORDER by sh.dateShared DESC ";

            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = sqlUserList1;
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = query2;
            cmd3.Parameters.AddWithValue("@userID", Session["CurrentUser"]);
            SqlDataReader reader3 = cmd3.ExecuteReader();


            while (reader3.Read())
            {
                dt.Rows.Add(reader3.GetValue(0).ToString(), reader3.GetValue(1).ToString(), reader3.GetValue(2).ToString(), reader3.GetValue(3).ToString());
            }
            
            //dt.Rows.Add("John Hammond");
            friends.DataSource = dt;
            friends.DataBind();
        }

        protected void friends_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void friends_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("feed.aspx?textID=" + friends.SelectedValue);
        }
    }
}