<%@ Page Title="Sign Up!" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="NewUser.aspx.cs" Inherits="Lab3.WebForm3" %>

<%-- File: NewUser.aspx --%>
<%-- Author: Vinson Sack --%>
<%-- Date: 09/27/2021 --%>
<%-- Purpose: Allows a user to sign up for out app  --%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <%-- create a container to place web form in container broken down into rows which contain different parts of the web form to be filled in  --%>
    <div class="container border border-1 bg-light">
        <div class="row">
            <div class="col-12 border border-5">
                <center>
                    <br />
                    <h2>New User Sign Up</h2>
                </center>
            </div>
        </div>
        <br />
        <br />
        <%-- Main Content of the container --%>
        <div class="row">
            <div class="col-md-6 text-center">
                <asp:Label ID="lblUserName" runat="server" CssClass="form-label" Text="Username"></asp:Label>
                <asp:TextBox ID="txtUserName" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valUser" runat="server" ErrorMessage="Username required" ControlToValidate="txtUserName" SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-6 text-center">
                <asp:Label ID="lblPassword" runat="server" CssClass="form-label" Text="Password"></asp:Label>
                <asp:TextBox ID="txtPassword" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valPassword" runat="server" ErrorMessage="Password is required" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 text-center">
                <asp:Label ID="lblFirstName" runat="server" CssClass="form-label" Text="First Name"></asp:Label>
                <asp:TextBox ID="txtFirstName" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valFirstName" runat="server" ErrorMessage="First Name cannot be blank" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-6 text-center">
                <asp:Label ID="lblLastName" runat="server" CssClass="form-label" Text="Last Name"></asp:Label>
                <asp:TextBox ID="txtLastName" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valLastName" runat="server" ErrorMessage="Last Name Cannot be blank" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 text-center">
                <asp:Label ID="lblEmailAddress" runat="server" CssClass="form-label" Text="Email Address"></asp:Label>
                <asp:TextBox ID="txtEmail" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valEmail" runat="server" ErrorMessage="Email cannot be black" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-6 text-center">
                <asp:Label ID="lblPhoneNumber" runat="server" CssClass="form-label" Text="Phone Number"></asp:Label>
                <asp:TextBox ID="txtPhone" Text="" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 text-center">
                <asp:Label ID="lblStreet" runat="server" CssClass="form-label" Text="Street Address"></asp:Label>
                <asp:TextBox ID="txtStreet" Text="" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-2 text-center">
                <asp:Label ID="lblCity" runat="server" CssClass="form-label" Text="City"></asp:Label>
                <asp:TextBox ID="txtCity" Text="" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-2 text-center">
                <asp:Label ID="lblState" runat="server" CssClass="form-label" Text="State"></asp:Label>
                <asp:TextBox ID="txtState" Text="" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-2 text-center">
                <asp:Label ID="lblZip" runat="server" CssClass="form-label" Text="Zip Code"></asp:Label>
                <asp:TextBox ID="txtZip" Text="" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div>
                <asp:DropDownList ID="ddlReason" CssClass="form-control form-select" runat="server">
                    <asp:ListItem>Work</asp:ListItem>
                    <asp:ListItem>School</asp:ListItem>
                    <asp:ListItem>Fun</asp:ListItem>
                </asp:DropDownList>
            </div>

        </div>
        <br />
        <hr />
        <br />
        <%-- Button Section --%>
        <div class="text-center">
            <asp:Button ID="btnPopulate" runat="server" Text="Populate" Width="170px" CssClass="btn btn-outline-primary" OnClick="btnPopulate_Click" CausesValidation="false" />
            <asp:Button ID="btnClear" runat="server" Text="Clear" Width="170px" CssClass="btn btn-outline-danger" OnClick="btnClear_Click" />
            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
        </div>
        <br />  
        <div class="row">
            <div class="text-center">   
                <asp:Button ID="btnSignUp" runat="server" Text="Sign Up!" Width="170px" CssClass="btn btn-outline-success" OnClick="btnSignUp_Click" />
            </div>
        </div>
        <br />
    </div>
</asp:Content>
