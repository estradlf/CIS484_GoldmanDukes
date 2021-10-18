using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Net;
using System.Text;
using System.Net.Http; // NuGet WebAPI
using System.Net.Http.Headers;
using System.Text.Json; // NuGet New Package

// File: GetAnalysis.aspx.cs
// Author: Vinson Sack
// Date: 10/7/2021
// Purpose: Logic behind the Get Analysis webform provides functionality to it 

namespace Lab3
{
    public partial class GetAnalysis : System.Web.UI.Page
    {
        HttpClient hClient = new HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {//smart page 
            if (Session["UserName"] != null)
            {
                if (!IsPostBack)
                {
                    //want to make this link work with the current user | Change inserts to hold at least one valid email that has submitted to SA
                    //for now its dr.ezells -- May change back to mitri because he has alot to work with 
                    String URL = "http://saworker.storyanalyzer.org/saresults.php?uid=ezelljd@jmu.edu&request=listsaextracts"; // set to your email address 
                    var response = hClient.GetStringAsync(new Uri(URL)).Result;
                    var jsondata = JsonDocument.Parse(response);
                    ddlSAList.Items.Clear();

                    foreach (var item in jsondata.RootElement.EnumerateArray())
                    {
                        var text = item.GetProperty("userid").GetString()
                            + " " + item.GetProperty("extractrequestdate").GetString();

                        var value = "uid=" + item.GetProperty("userid").GetString()
                            + "&extractrequesttime=" + item.GetProperty("extractrequestdate").GetString();

                        ddlSAList.Items.Add(new ListItem(text, value));
                    }
                }
            }
            else
            {
                Session["InvalidUse"] = "You must login first to use the application!";
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnMakeResuest_Click(object sender, EventArgs e)
        {
            String URL = "http://saworker.storyanalyzer.org/saresults.php?"
                + ddlSAList.SelectedValue.ToString()
                + "&request="
                + ddlRequest.SelectedItem.ToString();

            // Issue the GET command to the SA Server and get the response.
            var response = hClient.GetStringAsync(new Uri(URL)).Result;


            // The response could be plain text for some API commands
            //  or it could be HTML (to show a visualization)
            if (ddlRequest.SelectedIndex >= 0 && ddlRequest.SelectedIndex <= 3)
            {
                // The result is plain text: A URL for the source for example or story title.
                txtDisplay.Text = response;
            }
            else if (ddlRequest.SelectedItem.ToString().Equals("showbootstrapdashboard"))
            {
                // Here the user has selected to show the bootstrap dashboard.
                // We will open the URL for the dashboard in a new tab.
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + URL + "','_newtab');", true);               
            }
            else
            {
                // The results are HRML for a visualization. I'll replace the contents
                // of a DIV on the ASP.net form with the results
                // This will dynamically update the HTML page.
                displayViz.InnerHtml = response; // NOTE: acting up, didn't have time to edit fully 
                txtDisplay.Text = response; 
            }
        }
    }
}