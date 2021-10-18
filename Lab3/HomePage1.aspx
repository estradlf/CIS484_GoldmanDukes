﻿<%@ Page Title="Home" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="HomePage1.aspx.cs" Inherits="Lab3.WebForm2" %>

<%-- File: HomePage1.aspx --%>
<%-- Author: Vinson Sack --%>
<%-- Date: 10/7/2021 --%>
<%-- Purpose: Homepage content for splash page  --%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        background-color: #EAF3F3;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <br />
        <br />  
        <%-- Main container for the login content --%>
        <div class="container bg-white">
            <br />
            <br />
            <div class="row">
                <div class="col-12">
                    <center>
                        <h2>Core Functions</h2>
                    </center>
                </div>
            </div>
            <br />  
            <br />  
            <%-- Quick Links to core functions of application --%>
            <div class="row">
                <div class="col-md-4 text-center" >
                    <br />  
                    <asp:Image ID="imgLibraryLogo" ImageUrl="/images/Libraryjpg.jpg" runat="server" Width="150px"  />
                    <h4>Library</h4>
                    <p class="text-justify">Quick link to access your saved stories</p>
                    <asp:Button ID="btnLibrary" runat="server" Text="Library" CssClass="btn btn-primary" Width="143.5" OnClick="btnLibrary_Click"/>
                </div>
                <div class="col-md-4 text-center">
                    <br />  
                    <asp:Image ID="imgUploadLogo" ImageUrl="/images/Upload.jpg" runat="server" Width="150px" />
                    <h4>Upload a Story</h4>
                    <p class="text-justify" >Upload a new text to be saved in your library </p>
                    <asp:Button ID="btnStory" runat="server" Text="Upload Story" CssClass="btn btn-primary" Width="143.5px" OnClick="btnStory_Click" />
                </div>
                <div class="col-md-4 text-center">
                    <br class="auto-style1" />  
                    <asp:Image ID="Image1" ImageUrl="/images/Anal.jpg" runat="server" Width="150px" CssClass="auto-style1" />
                    <h4>Request an Analysis</h4>
                    <p class="text-justify">Send a saved story to be analyzed</p>
                    <asp:Button ID="btnRequest" runat="server" Text="Request Analysis" CssClass="btn btn-primary" OnClick="btnRequest_Click" />
                </div>
            </div>
            <br />
            <br />
        </div>
    </section>



</asp:Content>
