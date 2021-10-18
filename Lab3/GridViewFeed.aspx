<%@ Page Title="Feed" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="GridViewFeed.aspx.cs" Inherits="Lab3.WebForm10" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            align-content: center!important;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container border border-1 bg-light">
        <div class="row">
            <div class="col-12 boarder border-5">
                <center>
                    <br />
                    <h2>User Feed</h2>
                </center>
            </div>
        </div>
        <br />
        <div class="align-items-center text-center">
            <asp:GridView ID="friends" DataKeyNames="ID" Width="100%" RowStyle-CssClass="rows" CssClass="MyGridView" PagerStyle-CssClass="pager" runat="server" AllowPaging="true" HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="5px" GridLines="Both" RowStyle-HorizontalAlign="Center" RowStyle-Height="15px" AutoGenerateColumns="false" OnRowDataBound="friends_RowDataBound" AutoGenerateSelectButton="true" OnSelectedIndexChanged="friends_SelectedIndexChanged" ></asp:GridView>
        </div>
        <br />
        <br />
    </div>

</asp:Content>
