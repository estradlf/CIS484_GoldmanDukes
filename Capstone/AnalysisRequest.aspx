<%@ Page Title="Request For Analysis" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="AnalysisRequest.aspx.cs" Inherits="Lab3.WebForm6" %>

<%-- File: AnalysisRequest.aspx --%>
<%-- Author: Vinson Sack --%>
<%-- Date: 10/07/2021 --%>
<%-- Purpose: Webform that allows someone to request for an analysis on a story Also produces dummy result data --%>

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
                    <h2>Analysis Request</h2>
                </center>
            </div>
        </div>
        <br />
        <br />
        <%-- main content of the container --%>
        <div class="row">
            <div class="col-md-6 text-center">
                <asp:Label ID="lblText" runat="server" CssClass="form-label" Text="Pick A Saved Story to be Analyzed"></asp:Label>
                <asp:DropDownList ID="ddlStory" runat="server" CssClass=" form-control form-select"></asp:DropDownList>
            </div>
            <div class="col-md-6 text-center">
                <asp:Label ID="lblReason" runat="server" CssClass="form-label" Text="Purpose for Request"></asp:Label>
                <asp:DropDownList ID="ddlReason" runat="server" CssClass="form-control form-select">
                    <asp:ListItem Text="Business" />
                    <asp:ListItem Text="Education" />
                    <asp:ListItem Text="Fun" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 text-center">
                <asp:Label ID="lblDate" runat="server" CssClass="form-label" Text="Date Added"></asp:Label>
                <asp:TextBox ID="txtDate" type="date" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                <asp:RequiredFieldValidator ID="valDate" runat="server" ErrorMessage="Date cannot be blank" SetFocusOnError="true" ForeColor="Red" ControlToValidate="txtDate"></asp:RequiredFieldValidator>
            </div>
        </div>
        <hr />
        <br />
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblStatus" runat="server" CssClass="form-label" Text="Analysis Status" Visible="false"></asp:Label>
                <asp:TextBox ID="txtStatus" runat="server" CssClass=" form-control" Text="" Visible="false"></asp:TextBox>
            </div>
        </div>
        <br />
        <%-- Button Section --%>
        <div>
            <center>
                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-outline-success" Width="170px" Text="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnPopulate" runat="server" CssClass="btn btn-outline-primary" Width="170px" Text="Populate" OnClick="btnPopulate_Click" CausesValidation="false" />
                <asp:Button ID="btnClear" runat="server" CssClass="btn btn-outline-danger" Width="170px" Text="Clear" OnClick="btnClear_Click" />
            </center>
        </div>
        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Width="500px"></asp:Label>
        <br />
        <hr />
        <br />
        <%-- Sharing Section will allow user to share with their friends  |  I want to put this functionality in other places but close on time --%>
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblResults" runat="server" CssClass="form-label" Text="Analysis Results" Visible="false"></asp:Label>
                <asp:TextBox ID="txtResults" runat="server" CssClass=" form-control" Text="" Visible="false"></asp:TextBox>
            </div>
        </div>
        <br />  
        <div class="row">
            <center>
                <asp:Label ID="lblShare" runat="server" Visible="false" Text="Share With A Friend!"></asp:Label>
                <asp:DropDownList ID="ddlFriends" Visible="false" CssClass="form-control form-select" runat="server"></asp:DropDownList>
            </center>
        </div>
        <br />
        <div>
            <center>
                <asp:Button ID="btnShare" CssClass="btn btn-success" Visible="false" runat="server" OnClick="btnShare_Click" Text="Share" />
            </center>
        </div>
        <br />
        <br />
    </div>
</asp:Content>
