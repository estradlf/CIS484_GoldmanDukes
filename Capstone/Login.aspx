<%@ Page Title="Login" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Lab3.WebForm1" %>

<%-- File: Login.aspx --%>
<%-- Author: Vinson Sack --%>
<%-- Date: 10/07/2021 --%>
<%-- Purpose: Encryted Login Page --%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <%-- Creating a container for login content to be placed in --%>
    <div class="container jumbotron bg-light boxshadow" style="width: 35%" align="center">

        <%-- Banner for login --%>
        <div class="card-header-pills bg-dark text-white text-center">
            <h2>Login Page</h2>
        </div>
        <%-- main content of login page | Chose to use email as username --%>
        <div class="form-group">
            <asp:Label ID="username" CssClass="text-dark" Text="Username" runat="server" />
            <asp:TextBox CssClass="form-control" ID="txtUsername" runat="server" Width="80%"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valUsername" runat="server" ErrorMessage="username is required" ControlToValidate="txtUsername" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>

        </div>
        <div class="form-group">
            <asp:Label ID="lblPassword" CssClass="text-dark" Text="Password" runat="server" />
            <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server" TextMode="Password" Width="80%"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valPassword" runat="server" ErrorMessage="Password is Required" ControlToValidate="txtPassword" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
        </div>
        <div>
            <%-- Login Button --%>
            <br />
           <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-success" OnClick="btnLogin_Click" />
            <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" CssClass="btn btn-primary" OnClick="btnSignUp_Click" CausesValidation="false" />
            <br />
            <br />
        </div>
        <div>
            <%-- Used throughout the app if redirected back to login will change to type of redirection --%>
            <asp:Label ID="lblStatus" Text="" runat="server" />
        </div>
    </div>
</asp:Content>
