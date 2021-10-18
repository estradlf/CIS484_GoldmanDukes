<%@ Page Title="User Profile" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="Bio.aspx.cs" Inherits="Lab3.WebForm4" %>

<%-- File: Bio.aspx --%>
<%-- Author: Vinson Sack --%>
<%-- Date: 10/7/2021 --%>
<%-- Purpose: Allow users to see their bio and edit their information | Add in a biography --%>

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
                    <h2>User Profile</h2>
                </center>
            </div>
        </div>
        <br />
        <br />
        <%-- Main Content of the container --%>

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
        <br />
        <hr />
        <br />
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblBio" runat="server" CssClass="form-label" Text="User Bio (Max 200 Characters!)"></asp:Label>
                <asp:TextBox ID="txtBio" runat="server" Text="" CssClass="form-control" placeholder="Add your bio here!"></asp:TextBox>
            </div>
        </div>
        <br />
        <hr />
        <%-- Friend Section | see who is your frined and how many of them you have  --%>
        <p class="text-center fw-bold">Friend Information</p>
        <div class="row">
            <div class="col-md-4 text-center">
                <asp:Label ID="lblFriendCount" runat="server" CssClass="form-label" Text="Number of Friends"></asp:Label>
                <asp:TextBox ID="txtFriendCount" ReadOnly="true" Text="" CssClass="form-control text-center" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-4 text-center">
                <asp:Label ID="lblFriendDDL" runat="server" CssClass="form-label" Text="A list of your friends"></asp:Label>
                <asp:DropDownList ID="ddlCurrentFriends" CssClass="form-control form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="col-md-4 text-center">
                <asp:Button ID="btnRemove" CssClass="btn btn-outline-danger" runat="server" Text="Remove Friend" OnClick="btnRemove_Click" />
            </div>
        </div>
        <br />
        <%-- Button Section --%>
        <div class="text-center">
            <asp:Button ID="btnPopulate" runat="server" Text="Populate" Width="170px" CssClass="btn btn-outline-primary" OnClick="btnPopulate_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="170px" CssClass="btn btn-outline-success" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnClear" runat="server" Text="Clear" Width="170px" CssClass="btn btn-outline-danger" OnClick="btnClear_Click" />
            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
        </div>
        <br />
        <div class="text-center">
            <asp:Button ID="btnLogout" runat="server" Text="Sign Out" Width="170px" CssClass="btn btn-outline-warning" OnClick="btnLogout_Click" />
        </div>
        <br />
    </div>

</asp:Content>
