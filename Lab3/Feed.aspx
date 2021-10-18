<%@ Page Title="Personal Feed" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="Feed.aspx.cs" Inherits="Lab3.WebForm9" %>

<%-- File: Feed.aspx --%>
<%-- Author: Vinson Sack --%>
<%-- Date: 10/07/2021 --%>
<%-- Purpose: Allows a user to see the results that have been shared w them --%>

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
                    <h2>Feed</h2>
                </center>
            </div>
        </div>
        <br />
        <br />
        <%-- main content of the container --%>

        <div class="row">
            <div class="col-md-6 text-center">
                <asp:Label ID="lblSharedBy" runat="server" CssClass="form-label" Text="Shared By"></asp:Label>
                <asp:TextBox ID="txtSharedBy" CssClass="form-control" Text="" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6 text-center">
                <asp:Label ID="lbltitle" runat="server" CssClass="form-label" Text="Title"></asp:Label>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Text=""></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 text-center">
                <asp:Label ID="lblSource" runat="server" CssClass="form-label" Text="Source"></asp:Label>
                <asp:TextBox ID="txtSource" CssClass="form-control" Text="" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6 text-center">
                <asp:Label ID="lblDateShared" runat="server" CssClass="form-label" Text="Date Shared"></asp:Label>
                <asp:TextBox ID="txtDateShared" runat="server" CssClass="form-control" Text=""></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12 text-center">
                <asp:Label ID="lblResults" runat="server" CssClass="form-label" Text="Analysis Results"></asp:Label>
                <asp:TextBox ID="txtResults" runat="server" CssClass=" form-control" Text=""></asp:TextBox>
            </div>
        </div>
        <br />
        <hr />
        <br />
        <div class="row">
            <div class="text-center">
                <asp:Label ID="lblReturn" runat="server" Text="Return back to feed!"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="text-center">
                <asp:Button ID="btnReturn" OnClick="btnReturn_Click" runat="server" Text="Return" CssClass="btn accordion-body btn-outline-success" />
            </div>
        </div>
        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Width="500px"></asp:Label>
        <br />
        <br />
    </div>

</asp:Content>
