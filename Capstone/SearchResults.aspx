<%@ Page Title="Search Results" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="SearchResults.aspx.cs" Inherits="Lab3.WebForm8" %>

<%-- File: SearchResults.aspx --%>
<%-- Author: Vinson Sack --%>
<%-- Date: 10/07/2021 --%>
<%-- Purpose: Where a user gets redirected to when searching for another user  --%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div class="container border border-1 bg-light">
        <div class="row">
            <div class="col-12 border border-5">
                <center>
                    <br />
                    <h2>Search Results</h2>
                </center>
            </div>
        </div>
        <br />
        <br />
        <%-- Main Content of the container --%>
        <div class="row">
            <div class="col-md-6 text-center">
                <asp:Label ID="lblFirstName" runat="server" CssClass="form-label" Text="First Name"></asp:Label>
                <asp:TextBox ID="txtFirstName" ReadOnly="true" Text="" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6 text-center">
                <asp:Label ID="lblLastName" runat="server" CssClass="form-label" Text="Last Name"></asp:Label>
                <asp:TextBox ID="txtLastName" ReadOnly="true" Text="" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 text-center">
                <asp:Label ID="lblEmailAddress" runat="server" CssClass="form-label" Text="Email Address"></asp:Label>
                <asp:TextBox ID="txtEmail" ReadOnly="true" Text="" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6 text-center">
                <asp:TextBox ID="txtUserID" Visible="false" ReadOnly="true" Text="" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <hr />
        <br />
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblBio" runat="server" CssClass="form-label" Text="User Bio (Max 200 Characters!)"></asp:Label>
                <asp:TextBox ID="txtBio" ReadOnly="true" runat="server" Text="" CssClass="form-control" placeholder="Add your bio here!"></asp:TextBox>
            </div>

        </div>
        <br />
        <%-- Button Section --%>
        <%-- Dynamic buttons based off of relationship of two users --%>
        <div class="text-center">
            <asp:Button ID="btnAddFriend" runat="server" Text="Add as Friend" Width="170px" CssClass="btn btn-outline-primary" OnClick="btnAddFriend_Click" />           
            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
            
        </div>
        <div class="text-center">
            <asp:Button ID="btnRemoveFriend" runat="server" Text="Remove Friend" Width="170px" CssClass="btn btn-outline-primary" OnClick="btnRemoveFriend_Click" />
        </div>

        <br />
    </div>
</asp:Content>
