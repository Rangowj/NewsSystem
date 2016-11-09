<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="News.NewsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .div1{
            margin-top:20px;
            margin-left:20px;
            font-size:25px;
        }
        label{
            margin-left:20px;
            font-size:20px;
        }
        .ddSort{
            width:150px;
            height:23px;
        }
        .txt1{
            height:23px;
            padding-left:2px;
        }
        .btn1,.btn2,.btn3{
            margin-left:1px;
        }
        .btn1,.btn2{
            width:70px;
            height:35px;
            border:1px solid RGB(22,155,213);
            background-color:RGB(22,155,213);
            border-radius:4px;
            color:white;
        }
        .btn3{
            width:80px;
            height:35px;
            background-color:white;
            border-radius:4px;
            border:1px solid #c4c4c4;
        }
        .gvNewsDatail{
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="div1"><b>新闻分类列表</b></div><br />
    <label>分类:</label>
    <asp:DropDownList ID="ddlSort" CssClass="ddSort" runat="server" ></asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:XMLConnectionString2 %>" SelectCommand="SELECT [NewsSortName] FROM [News_Sort]"></asp:SqlDataSource>
    <label>标题:</label>
    <asp:TextBox ID="txtTitle" CssClass="txt1" runat="server"></asp:TextBox>
    <asp:Button ID="btnSelect" CssClass="btn1" runat="server" Text="查询" OnClick="btnSelect_Click" />
    <asp:Button ID="btnAdd" CssClass="btn2" runat="server" Text="添加" OnClick="btnAdd_Click" />
    <asp:Button ID="btnDelete" CssClass="btn3" runat="server" Text="批量删除" />

    <br />
    <asp:GridView ID="GridView1" CssClass="gvNewsDatail" runat="server" AutoGenerateColumns="False">
        <Columns>
             <asp:TemplateField HeaderText="选择">
                <ItemTemplate>
                    <asp:CheckBox ID="cbChoose" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ID" HeaderText="新闻ID" />
            <asp:BoundField DataField="NewsSortName" HeaderText="新闻分类名称" />
            <asp:BoundField DataField="NewsTitle" HeaderText="新闻标题" />
            <asp:BoundField DataField="CreatedTime" HeaderText="创建时间" />
           
        </Columns>
    </asp:GridView>
    <br />

</asp:Content>
