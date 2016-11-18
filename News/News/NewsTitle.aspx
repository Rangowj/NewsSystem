 <%@ Page Title="" Language="C#" MasterPageFile="~/Reception.Master" AutoEventWireup="true" CodeBehind="NewsTitle.aspx.cs" Inherits="News.NewsTitle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .gv1{
            margin-left:20px;
            margin-top:20px; 
            border-color:black;
        }
        .ctTime{
            text-align:center;
        }
        .nTitle{
            padding-left:10px;
        }
        .Title{
            padding-top:5px;
            padding-bottom:5px;
        }
        .item_Title{
            color:black;
            text-decoration:none;
            padding-left:10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:GridView ID="gvTitle" CssClass="gv1" runat="server" AutoGenerateColumns="False" Width="804px" >
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="id,NewsTitle" DataTextField="NewsTitle" HeaderText="新闻标题" DataNavigateUrlFormatString="NewsContent.aspx?id={0}&amp;NewsTitle={1}">
                <HeaderStyle CssClass="Title" />
                <ItemStyle CssClass="item_Title" />
                </asp:HyperLinkField>
                <asp:BoundField DataField="CreatedTime" HeaderText="发布时间" >
                    <ItemStyle Width="200px" CssClass="ctTime" Height="30px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
</asp:Content>
