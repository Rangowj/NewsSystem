<%@ Page Title="" Language="C#" MasterPageFile="~/Reception.Master" AutoEventWireup="true" CodeBehind="NewsContent.aspx.cs" Inherits="News.NewsContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #ContentPlaceHolder1_lbContent{
            margin-left:30px;
            position:relative;
            top:30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lbContent" runat="server" Text="Label"></asp:Label>
    <br />
</asp:Content>
