<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewsSortEdit.aspx.cs" Inherits="News.NewsSortEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .div1{
            font-size:25px;
            margin-top:20px;
            margin-left:40px;
        }
        label{
            font-size:20px;
            margin-left:40px;
        }
        .txt1{
            width:210px;
            height:25px;
            padding-left:3px;
            border-radius:2px;
            border:1px solid #c4c4c4;
        }
        .btn1{
            margin-left:20px;
            background-color:RGB(22,155,213);
            border-radius:4px;
            width:70px;
            height:35px;
            border:1px solid RGB(22,155,213);
            color:white;
        }
        .btn2{
            margin-left:10px;
            background-color:white;
            width:80px;
            height:35px;
            border:1px solid #c4c4c4;
            border-radius:4px;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="div1"><b>编辑新闻分类</b></div>
    <br />
    <label>分类名称</label>
    <asp:TextBox ID="txtSort" CssClass="txt1" runat="server"></asp:TextBox>
    <asp:Button ID="btnSave" CssClass="btn1" runat="server" Text="保存" OnClick="btnSave_Click" />
    <asp:Button ID="btnReturn" CssClass="btn2" runat="server" Text="返回列表" OnClick="btnBack_Click" />
</asp:Content>
