<%@ Page Title="Library" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="Library.aspx.cs" Inherits="Lab3.WebForm7" %>

<%-- File: AnalysisRequest.aspx --%>
<%-- Author: Vinson Sack --%>
<%-- Date: 09/27/2021 --%>
<%-- Purpose: Gridviews to act as library for the users saved stories as well as their analyzed stories  --%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <br />
    <%-- Main container for content --%>
    <div class="container border border-1 bg-light container-fluid">
        <div class="row">
            <center>
                <br />
                <h2>Library of Stored Stories</h2>
            </center>
        </div>
        <%-- saved stories Grid AKA Inner Join | Page is static and set to upload userID 1 --%>
        <div class="align-content-center">
            <div class="text-center">
                <asp:GridView ID="GridView1"
                    AllowSorting="true"
                    AutoGenerateColumns="false"
                    AutoGenerateEditButton="true"
                    DataKeyNames="textID"
                    DataSourceID="sqlLibrary"
                    runat="server"
                    GridLines="Both"
                    AllowPaging="True"
                    Width="90%" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" HorizontalAlign="Center">
                    <AlternatingRowStyle BackColor="Silver" BorderColor="Black" BorderStyle="Groove" BorderWidth="1px" HorizontalAlign="Left" VerticalAlign="Middle" />
                    <Columns>
                        <asp:BoundField HeaderText="Title"
                            DataField="title" SortExpression="title" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="2px" />
                        <asp:BoundField HeaderText="Source"
                            DataField="source" SortExpression="source" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="2px" />
                        <asp:BoundField HeaderText="Body" SortExpression="body"
                            DataField="body" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="2px" />
                        <asp:BoundField HeaderText="Date Added"
                            DataField="dateAdded" SortExpression="dateAdded" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="2px" />
                        <asp:BoundField HeaderText="Description"
                            DataField="description" SortExpression="description" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="2px" />
                    </Columns>
                    <EditRowStyle BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                    <HeaderStyle BackColor="#999999" BorderColor="Black" BorderStyle="Solid" />
                    <RowStyle BackColor="#E0E0E0" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                    <SelectedRowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                </asp:GridView>
            </div>
            <%-- datasource for first grid view  --%>
            <asp:SqlDataSource ID="sqlLibrary"
                ConnectionString="<%$ ConnectionStrings:Lab3 %>"
                SelectCommand="SELECT s.textID, s.title, s.source, s.body, s.dateAdded, s.description FROM dbo.StoryText s, Users u
                WHERE s.userID = u.userID
                AND u.userID = 1
                ORDER BY s.textID ASC"
                UpdateCommand="UPDATE StoryText SET title=@title, source=@source, body=@body, dateAdded=@dateAdded, description =@description WHERE textID=@textID"
                runat="server">
                <UpdateParameters>
                    <asp:Parameter Type="String" Name="textID" />
                    <asp:Parameter Type="String" Name="title" />
                    <asp:Parameter Type="String" Name="source" />
                    <asp:Parameter Type="String" Name="body" />
                    <asp:Parameter Type="String" Name="dateAdded" />
                    <asp:Parameter Type="String" Name="description" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
        <br />
        <br />
        <%-- Grid view for stories that have been analyzed | Page is static to user1 | OUTER JOIN --%>
        <div class="row">
            <center>
                <br />
                <h2>Library of Analyzed Stories</h2>
            </center>
        </div>

        <div class="align-content-center">
            <div class="text-center">
                <asp:GridView ID="GridView2"
                    AllowSorting="true"
                    AutoGenerateColumns="false"
                    DataKeyNames="analysisID"
                    DataSourceID="sqlAnalysisLibrary"
                    runat="server"
                    GridLines="Both"
                    AllowPaging="True"
                    AutoGenerateDeleteButton="true"
                    Width="90%" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" HorizontalAlign="Center">
                    <AlternatingRowStyle BackColor="Silver" BorderColor="Black" BorderStyle="Groove" BorderWidth="1px" HorizontalAlign="Left" VerticalAlign="Middle" />
                    <Columns>
                        <asp:BoundField HeaderText="Story Title"
                            DataField="title" SortExpression="title" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="2px" />
                        <asp:BoundField HeaderText="Analysis Date"
                            DataField="analysisDate" SortExpression="analysisDate" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="2px" />
                        <asp:BoundField HeaderText="Reason"
                            DataField="analysisReason" SortExpression="analysisReason" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="2px" />
                        <asp:BoundField HeaderText="Analysis Results" SortExpression="analysisResults"
                            DataField="analysisResults" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="2px" />
                        <asp:BoundField HeaderText="Status"
                            DataField="analysisStatus" SortExpression="analysisStatus" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderWidth="2px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="2px" />
                    </Columns>
                    <EditRowStyle BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                    <HeaderStyle BackColor="#999999" BorderColor="Black" BorderStyle="Solid" />
                    <RowStyle BackColor="#E0E0E0" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Left" />
                    <SelectedRowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                </asp:GridView>
            </div>

            <%-- SQL data source for gridview 2 Outer join used here --%>
            <asp:SqlDataSource ID="SqlAnalysisLibrary"
                ConnectionString="<%$ ConnectionStrings:Lab3 %>"
                SelectCommand="SELECT StoryText.title, AnalysisTask.analysisID, AnalysisTask.userID, AnalysisTask.textID, AnalysisTask.analysisDate, AnalysisTask.analysisReason, AnalysisTask.analysisResults, AnalysisTask.analysisStatus
                FROM StoryText RIGHT OUTER JOIN AnalysisTask
                ON StoryText.textID = AnalysisTask.textID
                WHERE StoryText.userID = 1"
                runat="server"
                DeleteCommand="DELETE FROM ShareResults WHERE taskID=@analysisID">
                <DeleteParameters>
                    <asp:Parameter Type="String" Name="analysisID" />
                    <asp:Parameter Type="String" Name="userID" />
                    <asp:Parameter Type="String" Name="textID" />
                    <asp:Parameter Type="String" Name="analysisDate" />
                    <asp:Parameter Type="String" Name="analysisReason" />
                    <asp:Parameter Type="String" Name="analysisResults" />
                    <asp:Parameter Type="String" Name="analysisStatus" />
                </DeleteParameters>
            </asp:SqlDataSource>
            <br />
            <br />
        </div>        
    </div>
</asp:Content>
