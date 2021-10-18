<%@ Page Title="Analyzed Results" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="GetAnalysis.aspx.cs" Inherits="Lab3.GetAnalysis" %>

<%-- File: GetAnalysis.aspx --%>
<%-- Author: Vinson Sack --%>
<%-- Date: 10/07/2021 --%>
<%-- Purpose: Webform that will interact with the SA via REST queries | Note: Due to time constraints I did not have much time to edit your code, my apologies --%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <%-- Container for main content of the page  --%>
    <div class="container border border-1 bg-light">
        <div class="row">
            <div class="col-12 boarder border-5">
                <center>
                    <br />
                    <h2>Analyzed Library</h2>
                </center>
            </div>
        </div>
        <br />
        <br />
        <%-- Web Forms broken down into rows --%>
        <div class="row">
            <div class="col-md-6 text-center">
                <asp:Label ID="lblSelectAnalysis" runat="server" CssClass="form-label" Text="Choose an Analysis"></asp:Label>
                <asp:DropDownList ID="ddlSAList" CssClass="form-control form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-3 text-center">
                <asp:Label ID="lblRequests" runat="server" CssClass="form-label" Text="Pick what you would like to see!"></asp:Label>
                <asp:DropDownList ID="ddlRequest" CssClass="form-control form-select" runat="server">
                    <asp:ListItem Text="gettitle"></asp:ListItem>
                    <asp:ListItem Text="getsource"></asp:ListItem>
                    <asp:ListItem Text="getpeople"></asp:ListItem>
                    <asp:ListItem Text="getplaces"></asp:ListItem>
                    <asp:ListItem Text="getvisinteractionschord"></asp:ListItem>
                    <asp:ListItem Text="getvisnarrativeweb"></asp:ListItem>
                    <asp:ListItem Text="getviswordcloud-subjects"></asp:ListItem>
                    <asp:ListItem Text="getviswordcloud-places"></asp:ListItem>
                    <asp:ListItem Text="getviswordcloud-people"></asp:ListItem>
                    <asp:ListItem Text="getviswordcloud-groups"></asp:ListItem>
                    <asp:ListItem Text="getsentencedetails"></asp:ListItem>
                    <asp:ListItem Text="showdashboard"></asp:ListItem>
                    <asp:ListItem Text="showbootstrapdashboard"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />

            <div class="col-md-3 text-center">
                <asp:Label ID="lblSpacer" runat="server" CssClass="form-label" Text="Submit When Ready"></asp:Label>
                <asp:Button ID="btnMakeResuest" CssClass="form-control" runat="server" Text="Submit" OnClick="btnMakeResuest_Click" />
            </div>
        </div>
        <hr />
        <h3 class="text-center">Results</h3>
        <div class="align-content-center">
            <asp:TextBox ID="txtDisplay" runat="server" Rows="15" Height="200" Width="100%" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
        </div>

        <br />
        <br />
    </div>
    <div class="container border border-1 bg-dark">
        <div runat="server" id="displayViz"></div>
    </div>
</asp:Content>
