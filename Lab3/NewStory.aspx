<%@ Page Title="New Story" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="NewStory.aspx.cs" Inherits="Lab3.WebForm5" %>

<%-- File: NewStory.aspx --%>
<%-- Author: Vinson Sack --%>
<%-- Date: 10/07/2021 --%>
<%-- Purpose: Allows the user to add a new story to their library --%>

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
                    <h2>New Story</h2>
                </center>
            </div>
        </div>
        <br />
        <br />
        <%-- Web Forms broken down into rows --%>
        <div class="row">
            <div class="col-md-6 text-center">
                <asp:Label ID="lblTitle" runat="server" CssClass="form-label" Text="Title"></asp:Label>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                <asp:RequiredFieldValidator ID="valTitle" runat="server" ErrorMessage="Title cannot be blank" SetFocusOnError="true" ForeColor="Red" ControlToValidate="txtTitle"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-6 text-center">
                <asp:Label ID="lblSource" runat="server" CssClass="form-label" Text="Source of Text"></asp:Label>
                <asp:TextBox ID="txtSource" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                <asp:RequiredFieldValidator ID="valSource" runat="server" ErrorMessage="Source cannot be blank" SetFocusOnError="true" ForeColor="Red" ControlToValidate="txtSource"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 text-center">
                <asp:Label ID="lblDescription" runat="server" CssClass="form-label" Text="Description of the Text"></asp:Label>
                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                <asp:RequiredFieldValidator ID="valDescription" runat="server" ErrorMessage="Description cannot be blank" SetFocusOnError="true" ForeColor="Red" ControlToValidate="txtDescription"></asp:RequiredFieldValidator>
            </div>
            <%-- Custom Validators used --%>
            <div class="col-md-6 text-center">
                <asp:Label ID="lblDate" runat="server" CssClass="form-label" Text="Date Added"></asp:Label>
                <asp:TextBox ID="txtDate" type="date" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                <asp:RequiredFieldValidator ID="valDate" runat="server" ErrorMessage="Date cannot be blank" SetFocusOnError="true" ForeColor="Red" ControlToValidate="txtDate"></asp:RequiredFieldValidator>
            </div>
        </div>
        <hr />
        <br />
        <%-- Copy and paste or File --%>
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblBody" runat="server" CssClass="form-label" Text="Body (Copy and Paste if you like)"></asp:Label>
                <asp:TextBox ID="txtBody" runat="server" CssClass="form-control" Rows="3"></asp:TextBox>
            </div>
        </div>
        <center>
            <br />
            <p>-- OR -- </p>
        </center>
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblFile" runat="server" Text="Choose File"></asp:Label>
               
                <asp:FileUpload ID="fileUpload" CssClass="form-control" type="file" runat="server" />
            </div>
        </div>
        <br />
        <br />
        <%-- Button Section --%>
        <div class="text-center">
            <asp:Button ID="btnSubmit" CssClass="btn btn-outline-success" runat="server" Text="Submit" OnClick="btnSubmit_Click" Width="150px" />
            <asp:Button ID="btnPopulate" CssClass="btn btn-outline-primary" runat="server" Text="Populate" OnClick="btnPopulate_Click" Width="150px" CausesValidation="false" />
            <asp:Button ID="btnClear" CssClass="btn btn-outline-danger" runat="server" Text="Clear" OnClick="btnClear_Click" Width="150px" />
            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        </div>
        <br />
        <br />
    </div>



</asp:Content>
