<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewsEdit.aspx.cs" Inherits="News.NewsEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .div1{
            font-size:25px;
            margin-top:20px;
            margin-left:40px;
        }
        .div2{
            text-align:center;
        }
        .btn1,.btn2{
            width:100px;
            height:37px;
        }
        .btn1{
            color:white;
            border:1px solid RGB(22,155,213);
            border-radius:4px;
            background-color:RGB(22,155,213);
        }
        .btn2{
            background-color:white;
            border:1px solid #c4c4c4;
            border-radius:4px;
        }
        #table,td{
            border:1px solid black;
            border-collapse:collapse;
            font-size:25px;
            text-align:center;
        }
        #table{
            margin-left:40px;
            margin-top:15px;
        }
        .td1{
            width:150px;                      
        }
        .td2{
            width:600px;   
            padding-bottom:7px;         
        }
        .tb1{
            width:580px;            
        }
        .td4{
            padding-bottom:7px;
        }
        .ddl1{
            width:582px;
            padding-top:3px;
            padding-bottom:3px;
        }
        .td5{
            height:400px;
        }
        .tb2{
            width:580px;
            height:390px;
            border:none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="div1"><b>新闻编辑</b></div>
    <table id="table">
        <tr>
            <td class="td1">新闻标题</td>
            <td class="td2">
                <asp:TextBox ID="tbTitle" CssClass="tb1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="td3">新闻分类</td>
            <th class="td4">
                <asp:DropDownList ID="ddlSort" CssClass="ddl1" runat="server" DataSourceID="SqlDataSource1" DataTextField="NewsSortName" DataValueField="NewsSortName"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=DESKTOP-KUU82FJ\SQLEXPRESS;Initial Catalog=XML;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [NewsSortName] FROM [News_Sort]"></asp:SqlDataSource>
            </th>
        </tr>
        <tr>
            <td class="td5">新闻内容</td>
            <td class="td6">
                <asp:TextBox ID="tbContent" CssClass="tb2" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div class="div2">
        <asp:Button ID="btnSave" CssClass="btn1" runat="server" Text="保存" OnClick="btnSave_Click" />
        <asp:Button ID="btnBack" CssClass="btn2" runat="server" Text="返回列表" OnClick="btnBack_Click" />
    </div>
</asp:Content>
