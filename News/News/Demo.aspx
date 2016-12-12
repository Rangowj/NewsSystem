<%@ Page Title="" Language="C#" MasterPageFile="~/Reception.Master" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="News.Demo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p id="pTitle"></p>

    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    <script src="jquery-3.1.1.min.js"></script>
    
</asp:Content>
